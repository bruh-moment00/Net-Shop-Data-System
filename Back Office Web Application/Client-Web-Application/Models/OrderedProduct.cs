using System;
using System.Collections.Generic;

#nullable disable

namespace Client_Web_Application.Models
{
    public partial class OrderedProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? UnitId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
