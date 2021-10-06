﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Back_Office_Web_Application.Context;
using Back_Office_Web_Application.Models;
using Back_Office_Web_Application.Models.Pagination;

namespace Back_Office_Web_Application.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Back_Office_Web_Application.Context.NetStoreDBContext _context;
        public PaginationModel<Product> productsPagination;

        public IndexModel(Back_Office_Web_Application.Context.NetStoreDBContext context)
        {
            _context = context;
            
        }

        public IList<Product> Product { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync(int p = 1, int s = 5)//TagHelper заставляет использовать именно такие переменные
        {
            Product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();

            var products = from prod in _context.Products
                           select prod;

            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Name.Contains(SearchString));
            }

            productsPagination = new PaginationModel<Product>(products, p, s);

            Product = await productsPagination.PaginatedList.ToListAsync();
        }
    }
}
