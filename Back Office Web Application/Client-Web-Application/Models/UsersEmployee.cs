using System;
using System.Collections.Generic;

#nullable disable

namespace Client_Web_Application.Models
{
    public partial class UsersEmployee
    {
        public UsersEmployee()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Role { get; set; }

        public virtual UsersEmployeesLogin IdNavigation { get; set; }
        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
