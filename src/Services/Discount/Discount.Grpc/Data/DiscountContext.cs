using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext :DbContext
{
    public DbSet<Coupon> Coupons { get; set; } = default!;

    public DiscountContext(DbContextOptions<DiscountContext> options) 
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon {Id = 1,ProductName = "IPhone15",Amount = 120000,Description = "Iphone is Good"},
            new Coupon { Id = 2, ProductName = "Nokia", Amount = 80000, Description = "I like Nokia" });
    }

}

