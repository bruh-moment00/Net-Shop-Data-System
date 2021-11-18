using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Models.QueryModels
{
    public class StockGetSingleResponse
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public StockStatus Status { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime? SellDate { get; set; }
        public Order? Order { get; set; }
    }
}
