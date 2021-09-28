using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Role { get; set; }

        public virtual EmployeesLogin IdNavigation { get; set; }
        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
