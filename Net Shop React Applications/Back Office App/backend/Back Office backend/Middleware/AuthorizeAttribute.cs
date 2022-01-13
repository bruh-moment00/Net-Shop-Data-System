using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Office_backend.Models.AuthModels;
using Back_Office_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Back_Office_backend.Models.QueryModels;

namespace Back_Office_backend.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;
        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles ?? new Role[] { };
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var account = (EmployeeGetSingleResponse)context.HttpContext.Items["User"];
            if (account == null || (_roles.Any() && !_roles.Contains(account.Role)))
            {
                // not logged in or role not authorized
                context.Result = new StatusCodeResult(401);
            }
        }
    }
}
