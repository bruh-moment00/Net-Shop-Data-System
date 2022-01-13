using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Back_Office_backend.Services;
using Back_Office_backend.Helpers;
using System.Text;

namespace Back_Office_backend.Middleware
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public JWTMiddleware(RequestDelegate next, IConfiguration configuration, IUserService userService)
        {
            _next = next;
            _configuration = configuration;
            _userService = userService;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault();

            if (token != null)
                token = token.Replace("Bearer ", ""); // Removing "Bearer " from token
                attachAccountToContext(context, token);

            await _next(context);
        }

        private void attachAccountToContext(HttpContext context, string token)
        {
            try
            {
                int userId = TokenDescriptor.GetUserIdFromToken(token, _configuration);

                context.Items["User"] = _userService.GetById(userId);
        }
            catch
            {

            }
        }
    }
}
