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

namespace Back_Office_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly NetStoreDBContext _context;
        //private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public AuthController(NetStoreDBContext context, IUserService userService)
        {
            //_context = context;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(LogIn))]
        public IActionResult LogIn([FromBody] LoginDataModel data)
        {
            if(data == null || string.IsNullOrWhiteSpace(data.Email) || string.IsNullOrWhiteSpace(data.Password))
            {
                return BadRequest("Введите логин и пароль");
            }

            var loginResponse = _userService.ValidateAndGetUserId(data);

            if(loginResponse == null)
            {
                return BadRequest("Неверный логин и/или пароль");
            }

            return Ok(loginResponse);
        }
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(nameof(GetResult))]
        public IActionResult GetResult()
        {
            return Ok("API Validated");
        }

        //private string GenerateJwtToken(int userId)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_configuration["JWT:key"]);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim("id", userId.ToString()) }),
        //        Expires = DateTime.UtcNow.AddHours(1),
        //        Issuer = _configuration["Jwt:Issuer"],
        //        Audience = _configuration["Jwt:Audience"],
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

    }
}
