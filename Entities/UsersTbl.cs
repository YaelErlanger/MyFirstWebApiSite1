using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class UsersTbl
{
    public int UserId { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [StringLength(5)]
    public string Password { get; set; }

    public virtual ICollection<OrdersTbl> OrdersTbls { get; set; } = new List<OrdersTbl>();
}
