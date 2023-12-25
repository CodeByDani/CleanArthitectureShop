using CleanArthitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace CleanArthitecture.Infrastructure.Persistence
{
    public class DBContextConnection(DbContextOptions<DBContextConnection> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderDetails { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //!ModelBuilder Configure
            modelBuilder.HasDefaultSchema("Sample");
            //! Configure From Model
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
