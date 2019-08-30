using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IslbTransfers.CustomAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Services;

namespace IslbTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(SessionAuthorizeAttribute))]
    public class EmailController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;

        public EmailController(IAccountService accountService, IEmailService emailService)
        {
            _accountService = accountService;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("verify_email")]
        public async Task<IActionResult> SendVerificationLink()
        {
            var user = _accountService.GetByEmail(User.Identity.Name);
            var protocol = HttpContext.Request.Scheme + "://";
            var domain = HttpContext.Request.Host;
            var linkToConfirm = "/#/verify";
            var code = await _emailService.GenerateVerificationCodeAsync(user.Id);
            var queryParameter = "?verification=" + code;
            user.EmailVerificationCode = code;
            _accountService.Update(user);
            var message = $"Confirmation link: <a href=\"{protocol + domain + linkToConfirm + queryParameter}\">Click here to complete verification</a>";
            await _emailService.SendEmailAsync(user.Email, "Email Confirmation", message);
            return Ok(new ResponseMessage {Message = $"Confirmation link successfully sent to {user.Email}. Please, read the email letter and follow the instructions.", Type = ResponseMessage.ResponseTypes.success, Duration = 10000});
        }

        [HttpPost]
        [Route("confirm_email")]
        public IActionResult ConfirmEmailVerification([FromBody]string code)
        {
            var user = _accountService.GetByEmail(User.Identity.Name);
            var response = new ResponseMessage {Duration = 5000};
            if (user.EmailVerificationCode.Equals(code))
            {
                user.IsEmailVerified = true;
                user.EmailVerificationCode = null;
                _accountService.Update(user);
                response.Message = "Thank you. Your email has been successfully verified!";
                response.Type = ResponseMessage.ResponseTypes.success;
                return Ok(response);
            }

            response.Message = "Wrong email verification code!";
            response.Type = ResponseMessage.ResponseTypes.error;
            return BadRequest(response);

        }
    }
}