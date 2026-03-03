using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ensure the Member Username is unique
        modelBuilder.Entity<Member>()
            .HasIndex(m => m.Username)
            .IsUnique();

        // Ensure the Member Email is unique
        modelBuilder.Entity<Member>()
            .HasIndex(m => m.Email)
            .IsUnique();
    }

    // Entities to be tracked by DbContext.
    public DbSet<Product> Products { get; set; }

    public DbSet<Member> Members { get; set; }
}
