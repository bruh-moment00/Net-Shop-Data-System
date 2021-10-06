using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_Web_Application.Models.Pagination
{
    public class PaginationModel<T>
    {
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public IQueryable<T> PaginatedList { get; set; }
        
        public PaginationModel(IQueryable<T> queryableList, int currentPage, int pageSize)
        {
            Count = queryableList.Count();
            CurrentPage = currentPage;
            PageSize = pageSize;

            PaginatedList = queryableList.ReturnPaginatedResult(CurrentPage, PageSize);
        }
    }
}
