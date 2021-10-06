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

namespace Back_Office_Web_Application.Pages.Stock
{
    public class IndexModel : PageModel
    {
        private readonly Back_Office_Web_Application.Context.NetStoreDBContext _context;
        public PaginationModel<StockList> pagination;

        public IndexModel(Back_Office_Web_Application.Context.NetStoreDBContext context)
        {
            _context = context;
        }

        public IList<Models.StockList> Stock { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync(int p = 1, int s = 15)
        {
            Stock = await _context._Stock
                .Include(s => s.Order)
                .Include(s => s.Product)
                .Include(s => s.Status).ToListAsync();

            var units = from unit in _context._Stock
                            select unit;

            if (!string.IsNullOrEmpty(SearchString))
            {
                units = from unit in units
                           where unit.Product.Name.Contains(SearchString) ||
                           unit.Product.Category.Name.Contains(SearchString) ||
                           unit.Product.Brand.Brand1.Contains(SearchString)
                        select unit;
            }

            pagination = new PaginationModel<StockList>(units, p, s);

            Stock = await pagination.PaginatedList.ToListAsync();
        }
    }
}
