using Microsoft.EntityFrameworkCore;
using work_01.Shared.Models;

namespace work_01.Server
{
	public class ProductDbContext:DbContext
	{
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options) { }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<OrderItem>().HasKey(o => new { o.OrderID, o.ProductID });
		}
	}
}
