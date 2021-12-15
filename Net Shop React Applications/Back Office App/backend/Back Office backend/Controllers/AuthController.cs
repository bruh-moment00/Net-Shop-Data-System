using Back_Office_backend.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly NetStoreDBContext _context;
        public AuthController(NetStoreDBContext context)
        {
            _context = context;
        }

        /*TODO
         * [HttpPost]
        public async Task<> Validate
         */

    }
}
