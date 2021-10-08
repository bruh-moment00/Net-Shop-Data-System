using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class UsersEmployeesLogin
    {
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public bool IsActive { get; set; }

        public virtual UsersEmployees UsersEmployees { get; set; }
    }
}
