using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderedProducts = new HashSet<OrderedProduct>();
            Stocks = new HashSet<StockList>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Status { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Cost { get; set; }
        public int? ManagerId { get; set; }

        public virtual UsersClient Client { get; set; }
        public virtual UsersEmployees Manager { get; set; }
        public virtual OrdersStatus StatusNavigation { get; set; }
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
        public virtual ICollection<StockList> Stocks { get; set; }
    }
}
