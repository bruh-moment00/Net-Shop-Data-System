﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Back_Office_Web_Application.Context;
using Back_Office_Web_Application.Models;

namespace Back_Office_Web_Application.Pages.Stock
{
    public class IndexModel : PageModel
    {
        private readonly Back_Office_Web_Application.Context.NetStoreDBContext _context;

        public IndexModel(Back_Office_Web_Application.Context.NetStoreDBContext context)
        {
            _context = context;
        }

        public IList<StockList> Stock { get;set; }

        public async Task OnGetAsync()
        {
            Stock = await _context.Stocks
                .Include(s => s.Order)
                .Include(s => s.Product)
                .Include(s => s.Status).ToListAsync();
        }
    }
}
