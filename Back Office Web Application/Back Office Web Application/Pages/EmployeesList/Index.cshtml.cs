using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Back_Office_Web_Application.Context;
using Back_Office_Web_Application.Models;
using Back_Office_Web_Application.Models.Pagination;

namespace Back_Office_Web_Application.Pages.EmployeesList
{
    public class IndexModel : PageModel
    {
        private readonly Back_Office_Web_Application.Context.NetStoreDBContext _context;
        public PaginationModel<UsersEmployees> pagination;

        public IndexModel(Back_Office_Web_Application.Context.NetStoreDBContext context)
        {
            _context = context;
        }

        public IList<UsersEmployees> UsersEmployees { get;set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync(int p = 1, int s = 10)
        {
            UsersEmployees = await _context.UsersEmployees
                .Include(u => u.IdNavigation)
                .Include(u => u.RoleNavigation).ToListAsync();

            var employees = from emp in _context.UsersEmployees
                           select emp;

            if (!string.IsNullOrEmpty(SearchString))
            {
                employees = from emp in employees
                            where emp.FirstName.Contains(SearchString) ||
                            emp.FirstName.Contains(SearchString) ||
                            emp.SecondName.Contains(SearchString) ||
                            emp.LastName.Contains(SearchString) ||
                            emp.Phone.Contains(SearchString) ||
                            emp.Id.ToString().Contains(SearchString) ||
                            emp.IdNavigation.Email.Contains(SearchString)
                            select emp;
            }

            pagination = new PaginationModel<UsersEmployees>(employees, p, s);
            
            UsersEmployees = await pagination.PaginatedList.ToListAsync();
        }
    }
}
