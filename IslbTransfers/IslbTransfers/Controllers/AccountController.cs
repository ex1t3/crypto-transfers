using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // LOGIN METHOD
        [Route("login")]
        [HttpPost]
        public ActionResult<UserClientData> Login([FromBody] UserLoginViewModel loginUser)
        {
            var checkedUser = _userService.CheckForUserIdentity(loginUser.Email, loginUser.Password);
            if (checkedUser == null) return BadRequest("Incorrect User Data");
            var userClientData = _userService.Authenticate(checkedUser);
            return Ok(userClientData);
        }

        // REGISTER METHOD
        [Route("register")]
        [HttpPost]
        public ActionResult<UserClientData> Register([FromBody] UserLoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                if (_userService.GetByEmail(loginUser.Email) != null) return BadRequest("Such Email address already exists");
                var registeredUser = new User()
                {
                    Email = loginUser.Email,
                    Password = _userService.HashPassword(loginUser.Password),
                    FullName = loginUser.Fullname,
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

        // LOGIN METHOD
        [Route("facebook")]
        [HttpPost]
        public async Task<ActionResult<UserClientData>> FacebookOAuth([FromBody]string token)
        {
            var userFbCredentials = await _userService.GetUserDataViaFacebook(token);
            if (userFbCredentials == null) return BadRequest("Something went wrong with your Facebook authentication...");
            var loggedUser = new User()
            {
                Email = userFbCredentials.email,
                FullName = userFbCredentials.name,
                Password = null,
                IsExtraLogged = true
            };
            var userClientData = new UserClientData()
            {
                IsExtraLogged = true,
                Email = loggedUser.Email,
                FullName = loggedUser.FullName
            };
            var userExternalLogin = _userService.GetExternalLogin(userFbCredentials.id);
            // If it's first time user being registered with facebook
            if (userExternalLogin == null)
            {
                userClientData.Token = _userService.Register(loggedUser).Token;
                _userService.AddExternalLogin(new UserExternalLogin()
                {
                    UserId = loggedUser.Id,
                    ProviderId = userFbCredentials.id,
                    ProviderName = "Facebook"
                });
                return Ok(userClientData);
            }

            // User is already registered with facebook, so just authenticate him
            else
            {
                loggedUser.Id = userExternalLogin.UserId;
                userClientData.Token = _userService.Authenticate(loggedUser).Token;
                userClientData.IsExtraLogged = true;
                return Ok(userClientData);
            }
        }
    }
}