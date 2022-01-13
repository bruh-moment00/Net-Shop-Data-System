using Back_Office_backend.Context;
using Back_Office_backend.Models;
using Back_Office_backend.Models.AuthModels;
using Back_Office_backend.Models.QueryModels;
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
        public string ValidateAndGetUserToken(LoginDataModel loginData)
        {
            var user = _context.UsersEmployeesLogins.Where(u => u.Email == loginData.Email).FirstOrDefault();

            UserDataForToken userToken = new UserDataForToken()
            {
                Id = user.EmployeeId,
                Password = loginData.Password
            };

            if (user != null)
            {
                if(BCrypt.Net.BCrypt.Verify(loginData.Password, user.HashPassword))
                {
                    var token = GenerateJwtToken(userToken);
                    return token;
                }
            }

            return null;
        }
        public EmployeeGetSingleResponse GetById(int userId)
        {
            var employee = _context.UsersEmployees.Find(userId);
            return new EmployeeGetSingleResponse
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                SecondName = employee.SecondName,
                LastName = employee.LastName,
                Phone = employee.Phone,
                Role = employee.Role
            };
        }

        private string GenerateJwtToken(UserDataForToken user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim("id", user.Id.ToString()),
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
