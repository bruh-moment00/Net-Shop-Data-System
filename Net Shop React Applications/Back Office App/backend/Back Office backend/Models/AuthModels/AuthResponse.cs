﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Models.AuthModels
{
    public class AuthResponse
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}
