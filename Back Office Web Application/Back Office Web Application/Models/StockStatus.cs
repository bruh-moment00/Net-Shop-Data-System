using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class StockStatus
    {
        public StockStatus()
        {
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
