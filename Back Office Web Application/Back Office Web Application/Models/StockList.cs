using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class StockList
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StatusId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime SellDate { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual StockStatus Status { get; set; }
    }
}
