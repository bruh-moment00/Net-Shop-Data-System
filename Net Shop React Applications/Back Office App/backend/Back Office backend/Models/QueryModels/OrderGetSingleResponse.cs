using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Models.QueryModels
{
    public class OrderGetSingleResponse
    {
        public int Id { get; set; }
        public UsersClient Client { get; set; }
        public OrdersStatus Status { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Cost { get; set; }
        public UsersEmployee? Manager { get; set; }
    }
}
