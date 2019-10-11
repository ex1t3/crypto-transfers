using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DAL.DbRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Model.Models;
using Service.Services;

namespace IslbTransfers.CustomAttributes
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly IAccountService _accountService;

        public SessionAuthorizeAttribute(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString()?.Substring(7);
            if (_accountService.IsSessionValid(token, context.HttpContext.User.Identity.Name)) return;
            context.Result = new BadRequestObjectResult("Your session isn't valid or has been expired.");
        }
    }
}
