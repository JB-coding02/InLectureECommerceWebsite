using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{

    // Entities to be tracked by DbContext.
    public DbSet<Product> Products { get; set; }
}
