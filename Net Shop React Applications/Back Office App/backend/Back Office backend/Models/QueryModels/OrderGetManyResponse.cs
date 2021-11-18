using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Office_backend.Models.QueryModels
{
    public class OrderGetManyResponse
    {
        public int Id { get; set; }
        public string ClientFullName { get; set; }
        public string Status { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Cost { get; set; }
        public int? ManagerId { get; set; }
    }
}
