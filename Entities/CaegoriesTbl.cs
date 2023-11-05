using System;
using System.Collections.Generic;

namespace Entities;

public partial class CaegoriesTbl
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ProductsTbl> ProductsTbls { get; set; } = new List<ProductsTbl>();
}
