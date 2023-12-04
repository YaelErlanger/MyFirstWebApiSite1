using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class UsersTbl
{
    public int UserId { get; set; }

    
    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;
    
    public string Password { get; set; } = null!;

    public virtual ICollection<OrdersTbl> OrdersTbls { get; set; } = new List<OrdersTbl>();
}
