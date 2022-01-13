using Back_Office_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Helpers
{
    public static class EnumRolesHelper
    {
        public static string GetRoleName(this Role role)
        {
            string roleName = "";
            switch (role)
            {
                case Role.Admin:
                    roleName = "Администратор";
                    break;
                case Role.Manager:
                    roleName = "Менеджер";
                    break;
            }
            return roleName;
        }
    }
}
