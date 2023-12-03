using System;
using System.Collections.Generic;

namespace Entities;

public partial class ProductsTbl
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public int? Price { get; set; }

    public string? Image { get; set; }

    public virtual CaegoriesTbl Category { get; set; } = null!;

    public virtual ICollection<OrderItemTbl> OrderItemTbls { get; set; } = new List<OrderItemTbl>();
}
