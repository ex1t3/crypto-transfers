using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IUserService _userService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AccountController(IUserService userService, IHostingEnvironment hostingEnvironment)
        {
            _userService = userService;
            _hostingEnvironment = hostingEnvironment;
        }

        // CHECK USER AUTH TOKEN AND RETURN USER DATA
        [Route("check")]
        [HttpGet]
        [ServiceFilter(typeof(SessionAuthorizeAttribute))]
        public IActionResult GetUserData()
        {
            var user = _userService.GetByEmail(User.Identity.Name);
            var userClientData = new UserClientData()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsExtraLogged = user.IsExtraLogged,
                SocketToken = _userService.GenerateSocketToken(user.Id)
            };
            return Ok(userClientData);
        }

        // LOGIN METHOD
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginViewModel loginUser)
        {
            var checkedUser = _userService.CheckForUserIdentity(loginUser.Email, loginUser.Password);
            if (checkedUser == null) return BadRequest("Incorrect User Data");
            if (checkedUser.IsExtraLogged)
                return BadRequest(
                    "Seems this user was registered via social media and can't be logged in. Use social buttons instead.");
            var userClientData = _userService.Authenticate(checkedUser);
            return Ok(userClientData);
        }

        // LOGOUT METHOD
        [Route("logout")]
        [HttpPost]
        [ServiceFilter((typeof(SessionAuthorizeAttribute)))]
        public IActionResult LogOut()
        {
            var user = _userService.GetByEmail(User.Identity.Name);
            var token = HttpContext.Request.Headers["Authorization"].ToString()?.Substring(7);
            if (user != null && token != null)
            {
                _userService.InValidateUserSession(user.Id, token);
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
                var uploadsPath = "UserUploads";
                var userUniqueFolder = _userService.GetByEmail(User.Identity.Name).Id;
                var directory = System.IO.Directory.CreateDirectory(this._hostingEnvironment.ContentRootPath + "\\" + uploadsPath + "\\" + userUniqueFolder);
                string uniqueFileName = DateTime.Now.ToBinary() + Path.GetExtension(file.FileName);
                using (FileStream stream = System.IO.File.Create(directory.FullName + "\\" + uniqueFileName))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new {fileName = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/uploads" + "/" + userUniqueFolder + "/" + uniqueFileName});

            }
            else
            {
                return BadRequest(new {error = "Something went wrong with uploading your file"});
            }
        }

        [Route("identity")]
        [HttpPost]
        [ServiceFilter((typeof(SessionAuthorizeAttribute)))]
        public IActionResult StoreUserIdentity(UserIdentityKyc userIdentity)
        {
           // store user kyc identity
           userIdentity.RecordCreatedTime = DateTime.Now;
           userIdentity.UserId = _userService.GetByEmail(User.Identity.Name).Id;
           return Ok(userIdentity);
        }

        // REGISTER METHOD
        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] UserLoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                if (_userService.GetByEmail(loginUser.Email) != null) return BadRequest("Such Email address already exists");
                var registeredUser = new User()
                {
                    Email = loginUser.Email,
                    Password = _userService.HashPassword(loginUser.Password),
                    FirstName = null,
                    LastName = null,
                    IsExtraLogged = false
                };
                var userClientData = _userService.Register(registeredUser);
                return Ok(userClientData);
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return BadRequest(errors);
        }

        // LOGIN METHOD VIA FACEBOOK
        [Route("oauth")]
        [HttpPost]
        public async Task<IActionResult> OAuthentication(OAuthProviderAccess oAuth)
        {
            var loggedUser = new User()
            {
                Password = null,
                IsExtraLogged = true
            };
            string providerId = "";
            switch (oAuth.Provider)
            {
                case "facebook":
                {
                    var userFbCredentials = await _userService.GetUserDataViaFacebook(oAuth.Token);
                    if (userFbCredentials == null) return BadRequest("Something went wrong with your Facebook authentication...");
                    loggedUser.Email = userFbCredentials.Email;
                    loggedUser.FirstName = userFbCredentials.FirstName;
                    loggedUser.LastName = userFbCredentials.LastName;
                    providerId = userFbCredentials.Id;
                    break;
                }

                case "google":
                {
                    var userGoogleCredentials = await _userService.GetUserDataViaGoogle(oAuth.Token);
                    if (userGoogleCredentials == null) return BadRequest("Something went wrong with your Google authentication...");
                    loggedUser.Email = userGoogleCredentials.Email;
                    loggedUser.FirstName = userGoogleCredentials.FirstName;
                    loggedUser.LastName = userGoogleCredentials.LastName;
                    providerId = userGoogleCredentials.Id;
                    break;
                }

                default:
                {
                    return BadRequest("Undefined OAuth network");
                }
            }

            UserClientData userClientData;

            var userExternalLogin = _userService.GetExternalLogin(providerId, oAuth.Provider);

            // If it's first time user being registered with facebook
            if (userExternalLogin == null)
            {
                if (_userService.GetByEmail(loggedUser.Email) != null) return BadRequest("Such Email address already exists");
                userClientData = _userService.Register(loggedUser);
                _userService.AddExternalLogin(new UserExternalLogin()
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
                userClientData = _userService.Authenticate(loggedUser);
            }

            userClientData.IsExtraLogged = true;
            return Ok(userClientData);
        }
    }
}