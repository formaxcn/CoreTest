using CoreASPNET.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreASPNET.Filters
{
    public class VerifyUserAttribute : Attribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Cookies["token"];
            if(!validateToken(token))
            {
                ResponseHelper.Write("Auth Error!", context.HttpContext.Response);
            }
        }

        private bool validateToken(String token)
        {
            //todo: customer token validate
            return token == "agent";
        }
    }
}
