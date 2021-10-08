using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class UsersClientsLogin
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool ActivatedProfile { get; set; }

        public virtual UsersClient UsersClient { get; set; }
    }
}
