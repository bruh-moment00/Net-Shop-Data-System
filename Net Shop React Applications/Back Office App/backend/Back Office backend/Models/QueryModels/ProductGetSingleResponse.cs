using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Models.QueryModels
{
    public class ProductGetSingleResponse
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Specs { get; set; }
        public string Image { get; set; }
    }
}
