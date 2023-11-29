using System;
using System.Collections.Generic;

namespace Entities;

public partial class OrdersTbl
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public double? OrderSum { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<OrderItemTbl> OrderItemTbls { get; set; } = new List<OrderItemTbl>();

    public virtual UsersTbl? User { get; set; }
}
