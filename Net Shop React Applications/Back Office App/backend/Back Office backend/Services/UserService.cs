using Back_Office_backend.Context;
using Back_Office_backend.Models.AuthModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Back_Office_backend.Services
{
    public class UserService : IUserService
    {
        private readonly NetStoreDBContext _context;
        private readonly IConfiguration _configuration;
        public UserService(NetStoreDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public AuthResponse ValidateAndGetUserId(LoginDataModel loginData)
        {
            var user = _context.UsersEmployeesLogins.Where(u => u.Email == loginData.Email).FirstOrDefault();
                
            if(user != null)
            {
                if(BCrypt.Net.BCrypt.Verify(loginData.Password, user.HashPassword))
                {
                    var token = GenerateJwtToken(user.EmployeeId);
                    return new AuthResponse()
                    {
                        UserId = user.EmployeeId,
                        Token = token
                    };
                }
            }

            return null;
        }
        public LoginDataModel GetById(int userId)
        {
            return (from user in _context.UsersEmployeesLogins
                    where user.EmployeeId == userId
                    select new LoginDataModel
                    {
                        Email = user.Email,
                        Password = user.HashPassword
                    }).FirstOrDefault();
        }

        private string GenerateJwtToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim("id", userId.ToString()),
                    new Claim("password", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
