using System;
using System.Collections.Generic;

namespace Entities;

public partial class OrderItemTbl
{
    public int OrderItemId { get; set; }

    public int? ProductId { get; set; }

    public int? OrderId { get; set; }

    public int? Quantity { get; set; }

    public virtual OrdersTbl? Order { get; set; }

    public virtual ProductsTbl? Product { get; set; }
}
