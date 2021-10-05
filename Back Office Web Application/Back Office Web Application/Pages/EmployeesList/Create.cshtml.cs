using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Back_Office_Web_Application.Context;
using Back_Office_Web_Application.Models;

namespace Back_Office_Web_Application.Pages.EmployeesList
{
    public class CreateModel : PageModel
    {
        private readonly Back_Office_Web_Application.Context.NetStoreDBContext _context;

        public CreateModel(Back_Office_Web_Application.Context.NetStoreDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Role"] = new SelectList(_context.Roles, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public UsersEmployees UsersEmployees { get; set; }
        [BindProperty]
        public UsersEmployeesLogin UsersEmployeesLogin { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string PasswordCheck { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!IsPasswordsEqual(Password, PasswordCheck))
            {
                return Page();
            }

            UsersEmployeesLogin.HashPassword = BCrypt.Net.BCrypt.HashPassword(Password);

            _context.UsersEmployeesLogins.Add(UsersEmployeesLogin);
            await _context.SaveChangesAsync();

            UsersEmployees.Id = UsersEmployeesLogin.EmployeeId;

            _context.UsersEmployees.Add(UsersEmployees);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool IsPasswordsEqual(string password, string passwordCheck)
        {
            if (password == passwordCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
