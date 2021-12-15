using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Paging
{
	public class PaginationModel<T>
	{
		public int CurrentPage { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }
		public List<T> Items { get; private set; }
		public bool HasPrevious => CurrentPage > 1;
		public bool HasNext => CurrentPage < TotalPages;

		public PaginationModel(List<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;

			TotalPages = (int)Math.Ceiling(count / (double)pageSize);

			Items = items;
		}

        public static PaginationModel<T> GetPagedModel(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();

			if (pageSize > 20) pageSize = 20;
			else if (pageSize < 1) pageSize = 1;

			if (pageNumber < 1) pageNumber = 1;

			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginationModel<T>(items, count, pageNumber, pageSize);
        }
    }
}
