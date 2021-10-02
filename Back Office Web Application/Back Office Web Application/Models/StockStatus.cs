using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class StockStatus
    {
        public StockStatus()
        {
            Stocks = new HashSet<StockList>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StockList> Stocks { get; set; }
    }
}
