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
        private IUserService _userService;

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
                var userClientData = _userService.Register(loginUser);
                if (userClientData == null) return BadRequest("Such Email address already exists");
                return Ok(userClientData);
            }
            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();
            return BadRequest(errors);
        }
    }
}