using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public interface IMyStore326659356Context
{
    IConfiguration _configuration { get; }
    DbSet<CaegoriesTbl> CaegoriesTbls { get; set; }
    DbSet<OrderItemTbl> OrderItemTbls { get; set; }
    DbSet<OrdersTbl> OrdersTbls { get; set; }
    DbSet<ProductsTbl> ProductsTbls { get; set; }
    DbSet<Rating> Ratings { get; set; }
    DbSet<UsersTbl> UsersTbls { get; set; }
}