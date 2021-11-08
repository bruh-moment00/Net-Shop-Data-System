using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_backend.Models
{
    public partial class Role
    {
        public Role()
        {
            UsersEmployees = new HashSet<UsersEmployee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersEmployee> UsersEmployees { get; set; }
    }
}
