using System;
using System.Collections.Generic;

#nullable disable

namespace Back_Office_backend.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderedProducts = new HashSet<OrderedProduct>();
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string SpecsString { get; set; }
        public string ImagePath { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
