using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class UsersClient
    {
        public UsersClient()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public bool? Gender { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual UsersClientsLogin IdNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
