﻿using ESC.AdministrationCore.Entities.DbSet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ESC.AdministrationCore.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];

            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized Access !!!" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
