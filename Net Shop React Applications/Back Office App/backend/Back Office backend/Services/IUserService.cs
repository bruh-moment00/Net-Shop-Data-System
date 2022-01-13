using Back_Office_backend.Models;
using Back_Office_backend.Models.AuthModels;
using Back_Office_backend.Models.QueryModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Back_Office_backend.Services
{
    public interface IUserService
    {
        string ValidateAndGetUserToken(LoginDataModel loginData);
        EmployeeGetSingleResponse GetById(int userId);
    }
}
