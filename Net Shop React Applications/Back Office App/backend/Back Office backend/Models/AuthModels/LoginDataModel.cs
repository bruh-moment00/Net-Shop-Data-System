using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Models.AuthModels
{
    public class LoginDataModel
    {
        [Required(ErrorMessage = "Введите email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}
