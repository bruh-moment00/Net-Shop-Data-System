using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Models.QueryModels
{
    public class StockGetManyResponse
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime? SellDate { get; set; }
        public int? OrderId { get; set; }
    }
}
