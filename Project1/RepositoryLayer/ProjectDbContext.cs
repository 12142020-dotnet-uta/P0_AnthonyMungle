
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;

namespace RepositoryLayer
{
    public class ProjectDbContext :  DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations {get; set; }
        public DbSet<Inventory> Inventories {get; set;}
        public DbSet<Cart> Carts {get; set;}

        public DbSet<Order> Orders { get; set; }

        public ProjectDbContext() { }
        public ProjectDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Project1;Trusted_Connection=True;");
            }
        }
    }
}