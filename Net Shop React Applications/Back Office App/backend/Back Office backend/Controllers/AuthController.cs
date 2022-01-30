using Back_Office_backend.Context;
using Back_Office_backend.Models.AuthModels;
using Back_Office_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using Back_Office_backend.Models.QueryModels;
using Back_Office_backend.Helpers;

namespace Back_Office_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost(nameof(LogIn))]
        public IActionResult LogIn([FromBody] LoginDataModel data)
        {
            if(data == null || string.IsNullOrWhiteSpace(data.Email) || string.IsNullOrWhiteSpace(data.Password))
            {
                return BadRequest("Введите логин и пароль");
            }

            var loginResponse = _userService.ValidateAndGetUserToken(data);

            if(loginResponse == null)
            {
                return BadRequest("Неверный логин и/или пароль");
            }

            return Ok(loginResponse);
        }
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(nameof(GetUserData))]
        public EmployeeGetSingleResponse GetUserData([FromHeader(Name = "Authorization")] string token)
        {
            token = token.Replace("Bearer ", "");
            int userId = TokenDescriptor.GetUserIdFromToken(token, _configuration);

            return _userService.GetById(userId);
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(nameof(IsTokenValid))]
        public ActionResult IsTokenValid()
        {
            return Ok("token valid");
        }
    }
}
