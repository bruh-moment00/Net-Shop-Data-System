using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class Role
    {
        public Role()
        {
            UsersEmployees = new HashSet<UsersEmployees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersEmployees> UsersEmployees { get; set; }
    }
}
