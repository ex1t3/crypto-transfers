using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IslbTransfers.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Services;

namespace IslbTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IHostingEnvironment hostingEnvironment, IMapper mapper)
        {
            _accountService = accountService;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        // CHECK USER AUTH TOKEN AND RETURN USER DATA
        [Route("check")]
        [HttpGet]
        [ServiceFilter(typeof(SessionAuthorizeAttribute))]
        public async Task<IActionResult> GetUserData()
        {
            var user = await _accountService.GetByEmailAsync(User.Identity.Name);
            return Ok(_accountService.GetClientSideDataAsync(user));
        }

        // LOGIN METHOD
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel loginUser)
        {
            var checkedUser = await _accountService.CheckForIdentityAsync(loginUser.Email, loginUser.Password);
            if (checkedUser == null) return BadRequest(new ResponseMessage { Message = "Incorrect User Data", Type = ResponseMessage.ResponseTypes.error, Duration = 3000 });
            if (checkedUser.IsExtraLogged)
                return BadRequest(
                    new ResponseMessage() { Message = "Seems this user was registered via social media and can't be logged in. Use social buttons instead.", Type = ResponseMessage.ResponseTypes.info, Duration = 10000 });
            var userClientData = await _accountService.AuthenticateAsync(checkedUser);
            return Ok(new { Message = new ResponseMessage { Message = "Login successful", Type = ResponseMessage.ResponseTypes.success, Duration = 3000 }, Data = userClientData });
        }

        // LOGOUT METHOD
        [Route("logout")]
        [HttpPost]
        [ServiceFilter((typeof(SessionAuthorizeAttribute)))]
        public async Task<IActionResult> LogOut()
        {
            var user = await _accountService.GetByEmailAsync(User.Identity.Name);
            var token = HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
            if (user != null)
            {
                _accountService.InValidateSession(user.Id, token);
            }
            return Ok();
        }

        // METHOD FOR UPLOADING FILES
        [Route("uploadfile")]
        [HttpPost]
        [ServiceFilter((typeof(SessionAuthorizeAttribute)))]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null)
            {
                const string uploadsPath = "UserUploads";
                var userUniqueFolder = _accountService.GetByEmailAsync(User.Identity.Name).Id;
                var directory = Directory.CreateDirectory(this._hostingEnvironment.ContentRootPath + "\\" + uploadsPath + "\\" + userUniqueFolder);
                var uniqueFileName = DateTime.Now.ToBinary() + Path.GetExtension(file.FileName);
                using (var stream = System.IO.File.Create(directory.FullName + "\\" + uniqueFileName))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { fileName = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/uploads" + "/" + userUniqueFolder + "/" + uniqueFileName });

            }
            else
            {
                return BadRequest(new ResponseMessage { Message = "Something went wrong with uploading your file", Type = ResponseMessage.ResponseTypes.error, Duration = 5000 });
            }
        }

        [Route("update_wallets")]
        [HttpPost]
        [ServiceFilter(typeof(SessionAuthorizeAttribute))]
        public async Task<IActionResult> UpdateUserWallets(UserWallet wallet)
        {
            var user = await _accountService.GetByEmailAsync(User.Identity.Name);
            if (user == null)
                return BadRequest(new ResponseMessage()
                {
                    Duration = 3000,
                    Message = "User unauthorized",
                    Type = ResponseMessage.ResponseTypes.error
                });
            wallet.UserId = user.Id;
            _accountService.UpdateWallets(wallet);
            return Ok(new ResponseMessage()
            {
                Duration = 3000,
                Message = "Wallets successfully updated",
                Type = ResponseMessage.ResponseTypes.success
            });
        }

        // METHOD USED FOR STORING USER'S IDENTITY DATA
        [Route("identity")]
        [HttpPost]
        [ServiceFilter((typeof(SessionAuthorizeAttribute)))]
        public async Task<IActionResult> StoreUserIdentity(UserIdentityViewModel userIdentity)
        {
            var mappedIdentity = _mapper.Map<UserIdentityKyc>(userIdentity);

            // store user kyc identity
            mappedIdentity.RecordCreatedTime = DateTime.Now;
            mappedIdentity.UserId = _accountService.GetByEmailAsync(User.Identity.Name).Id;
            await _accountService.AddIdentityAsync(mappedIdentity);
            return Ok(new { Message = new ResponseMessage { Message = "Your identity verification was successfully saved. Now give us some time to validate your data and accept the confirmation.", Type = ResponseMessage.ResponseTypes.success, Duration = 15000 }, Data = userIdentity });
        }

        // REGISTER METHOD
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserLoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                if (await _accountService.GetByEmailAsync(loginUser.Email) != null) return BadRequest(new ResponseMessage { Message = "Account with this email address already exists. Choose another one.", Type = ResponseMessage.ResponseTypes.error, Duration = 5000 });
                var registeredUser = new User()
                {
                    Email = loginUser.Email,
                    Password = _accountService.HashPassword(loginUser.Password),
                    FirstName = null,
                    LastName = null,
                    IsExtraLogged = false
                };
                var userClientData = await _accountService.RegisterAsync(registeredUser);
                return Ok(new { Message = new ResponseMessage { Message = "You were successfully registered", Type = ResponseMessage.ResponseTypes.success, Duration = 3000 }, Data = userClientData });
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return BadRequest(new ResponseMessage { Message = errors.Count + " fields weren't filled correct. Please, check input fields again.", Type = ResponseMessage.ResponseTypes.error, Duration = 6000, Errors = errors });
        }

        // LOGIN METHOD VIA SOCIAL BUTTONS
        [Route("oauth")]
        [HttpPost]
        public async Task<IActionResult> OAuthentication(OAuthProviderAccess oAuth)
        {

            var userOAuthData = await _accountService.GetDataViaSocialProvider(oAuth.Token, oAuth.Provider);
            if (userOAuthData == null) return BadRequest(new ResponseMessage { Message = "Something went wrong with your social authentication", Type = ResponseMessage.ResponseTypes.error, Duration = 8000 });

            var loggedUser = _mapper.Map<User>(userOAuthData);
            if (loggedUser.Email == null) return BadRequest(new ResponseMessage { Message = "Login failed. Social network couldn't provide the email address.", Type = ResponseMessage.ResponseTypes.error, Duration = 3000 });
            
            var providerId = userOAuthData.Id;

           UserClientSideData userClientSideData;

            var userExternalLogin = await _accountService.GetExternalLoginAsync(providerId, oAuth.Provider);

            // If it's first time user being registered with facebook
            if (userExternalLogin == null)
            {
                if (_accountService.GetByEmailAsync(loggedUser.Email) != null) return BadRequest(new ResponseMessage { Message = "Account with such email address already exists", Type = ResponseMessage.ResponseTypes.error, Duration = 3000 });
                userClientSideData = await _accountService.RegisterAsync(loggedUser);
                await _accountService.AddExternalLoginAsync(new UserExternalLogin()
                {
                    UserId = loggedUser.Id,
                    ProviderId = providerId,
                    ProviderName = oAuth.Provider
                });
            }

            // User is already registered with social provider, so just authenticate him
            else
            {
                loggedUser.Id = userExternalLogin.UserId;
                userClientSideData = await _accountService.AuthenticateAsync(loggedUser);
            }

            userClientSideData.IsExtraLogged = true;
            return Ok(new { Message = new ResponseMessage { Message = "Login successful", Type = ResponseMessage.ResponseTypes.success, Duration = 3000 }, Data = userClientSideData });
        }
    }
}