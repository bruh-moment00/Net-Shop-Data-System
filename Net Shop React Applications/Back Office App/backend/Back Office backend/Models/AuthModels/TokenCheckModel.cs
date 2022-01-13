using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Models.AuthModels
{
    public class TokenCheckModel
    {
        public DateTime ExpirationTime { get; set; }
        public bool IsExpired { get; set; }
    }
}
