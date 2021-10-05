using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Back_Office_Web_Application.Context;
using Back_Office_Web_Application.Models;

namespace Back_Office_Web_Application.Pages.EmployeesList
{
    public class DetailsModel : PageModel
    {
        private readonly Back_Office_Web_Application.Context.NetStoreDBContext _context;

        public DetailsModel(Back_Office_Web_Application.Context.NetStoreDBContext context)
        {
            _context = context;
        }

        public UsersEmployees UsersEmployees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UsersEmployees = await _context.UsersEmployees
                .Include(u => u.IdNavigation)
                .Include(u => u.RoleNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (UsersEmployees == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
