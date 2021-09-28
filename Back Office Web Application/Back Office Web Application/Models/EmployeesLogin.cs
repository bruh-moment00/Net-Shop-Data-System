using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class EmployeesLogin
    {
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public byte[] HashPassword { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
