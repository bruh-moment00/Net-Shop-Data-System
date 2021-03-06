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

namespace Back_Office_Web_Application.Pages.Products
{
    public class SelectCategoryModel : PageModel
    {
        private readonly Back_Office_Web_Application.Context.NetStoreDBContext _context;

        public SelectCategoryModel(Back_Office_Web_Application.Context.NetStoreDBContext context)
        {
            _context = context;
            
        }

        public IList<Category> Categories { get;set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories
                .ToListAsync();
        }
    }
}
