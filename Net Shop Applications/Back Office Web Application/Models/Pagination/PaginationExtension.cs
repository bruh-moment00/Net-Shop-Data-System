using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_Web_Application.Models
{
    public static class PaginationExtension
    {
        public static IQueryable<TSource> ReturnPaginatedResult<TSource>(this IQueryable<TSource> currentList, int currentPage, int pageSize)
        {
            return currentList.Skip((currentPage - 1) * pageSize).Take(pageSize);
        }
    }
}
