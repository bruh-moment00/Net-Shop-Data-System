using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Controllers
{
    public static class PagingExtension
    {
        public static IQueryable<TSource> ReturnPaginatedResult<TSource>(this IQueryable<TSource> currentList, int pageNumber, int pageSize)
        {
            int amountOfElementsSkipped = (pageNumber - 1) * pageSize;
            return currentList.Skip(amountOfElementsSkipped).Take(pageSize);
        }
    }
}
