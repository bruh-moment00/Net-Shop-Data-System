using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Back_Office_Web_Application.Context;
using Back_Office_Web_Application.Models;

namespace Back_Office_Web_Application.Pages.EmployeesList
{
    public class EditModel : PageModel
    {
        private readonly Back_Office_Web_Application.Context.NetStoreDBContext _context;

        public EditModel(Back_Office_Web_Application.Context.NetStoreDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["Id"] = new SelectList(_context.UsersEmployeesLogins, "EmployeeId", "Email");
           ViewData["Role"] = new SelectList(_context.Roles, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UsersEmployees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersEmployeesExists(UsersEmployees.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UsersEmployeesExists(int id)
        {
            return _context.UsersEmployees.Any(e => e.Id == id);
        }
    }
}
