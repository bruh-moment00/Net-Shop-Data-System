using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_Web_Application.Models
{
    public class PaginationModel
    {
        [Microsoft.AspNetCore.Mvc.BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        
        public PaginationModel(int currentPage, int count, int pageSize)
        {
            CurrentPage = currentPage;
            Count = count;
            PageSize = pageSize;
        }
    }
}
