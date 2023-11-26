using Entities;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public double? OrderSum { get; set; }

        public int? UserId { get; set; }

        public  ICollection<OrderItemTbl> OrderItemTbls { get; set; } = new List<OrderItemTbl>();
       


    }
}
