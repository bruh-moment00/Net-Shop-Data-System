using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Back_Office_Web_Application.Context;
using Back_Office_Web_Application.Models;
using Microsoft.AspNetCore.Authorization;

namespace Back_Office_Web_Application.Pages.Authorization
{
    
    public class LoginModel : PageModel
    {
        private Back_Office_Web_Application.Context.NetStoreDBContext _context;
        [BindProperty]
        public LoginData LoginData { get; set; }
        public LoginModel(Back_Office_Web_Application.Context.NetStoreDBContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            UsersEmployeesLogin currentUser = (from user in _context.UsersEmployeesLogins
                                               where user.Email == LoginData.Email
                             select user).FirstOrDefault();

            if(currentUser != null)
            {
                if (BCrypt.Net.BCrypt.Verify(LoginData.Password, currentUser.HashPassword))
                {

                    var identity = new ClaimsIdentity(ReturnClaimsList(currentUser), "AuthenticationCookie");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("AuthenticationCookie", claimsPrincipal);

                    return RedirectToPage("/Index");
                }
            }
            
            

            return Page();
        }

        private List<Claim> ReturnClaimsList(UsersEmployeesLogin userLogin)
        {
            List<Claim> claims = new List<Claim>();
            var userData = (from user in _context.UsersEmployees
                            where user.Id == userLogin.EmployeeId
                            join role in _context.Roles on user.Role equals role.Id
                            select new
                            {
                                Name = String.Format("{0} {1} {2}", user.LastName, user.FirstName, user.SecondName),
                                Role = role.Name
                            }).FirstOrDefault();

            claims.Add(new Claim(ClaimTypes.Name, userData.Name));
            claims.Add(new Claim(ClaimTypes.Role, userData.Role));

            return claims;
        }
    }

    public class LoginData
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
