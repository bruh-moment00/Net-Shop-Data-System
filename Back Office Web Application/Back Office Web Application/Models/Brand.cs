using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_Web_Application.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Brand1 { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
