using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using System;

namespace OnlineShop.Data
{
    public class OnlineShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NapredneTest;Trusted_Connection=True;");
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ImageUrl).IsRequired();
            modelBuilder.Entity<Product>().HasOne(pr => pr.ProductType).WithMany().HasForeignKey(pr => pr.ProductTypeId).OnDelete(DeleteBehavior.Restrict);

            // ProductType
            modelBuilder.Entity<ProductType>().Property(pt => pt.Name).IsRequired();

            // User, Admin, Customer
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.IsAdmin).IsRequired();

            modelBuilder.Entity<Admin>().HasBaseType<User>().ToTable("Admins");

            modelBuilder.Entity<Customer>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.LastName).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired();
            modelBuilder.Entity<Customer>().HasOne(ci => ci.City).WithMany().HasForeignKey(ci => ci.CityId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>().HasBaseType<User>().ToTable("Customers");

            // City
            modelBuilder.Entity<City>().Property(ci => ci.CityName).IsRequired();

            // Order
            modelBuilder.Entity<Order>().Property(o => o.Status)
                .HasConversion(s => s.ToString(), s => (OrderStatus)Enum.Parse(typeof(OrderStatus), s));
            modelBuilder.Entity<Order>().HasOne(c => c.Customer).WithMany().HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>().OwnsMany(o => o.OrderItems, oi =>
            {
                oi.WithOwner(oi => oi.Order);
                oi.HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
