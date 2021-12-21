using Back_Office_backend.Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Services
{
    public interface IUserService
    {
        AuthResponse ValidateAndGetUserId(LoginDataModel loginData);
        LoginDataModel GetById(int userId);
    }
}
