using E_CommerceMangementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_CommerceMangementSystem.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) 
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(a => a.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Entity<User>()
                .HasMany(a => a.orders)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(a => a.OrderItems)
                .WithOne(a => a.Order)
                .HasForeignKey(a => a.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(a => a.OrderItems)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId);

            modelBuilder.Entity<OrderItem>()
                .HasIndex(a => new { a.OrderId, a.ProductId })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(a => a.Name)
                .IsUnique();


            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@example.com",
                    Password = "123456A",
                    Role = "Customer",
                },
                new User
                {
                    Id = 3,
                    FullName = "Store Admin",
                    Email = "admin@example.com",
                    Password = "123456Adm",
                    Role = "Admin",
                },
                new User
                {
                    Id = 2,
                    FullName = "Mona Ali",
                    Email = "mona@example.com",
                    Password = "123456M",
                    Role = "Customer",
                }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic devices and accessories",
                },
                new Category
                {
                    Id = 2,
                    Name = "Books",
                    Description = "Programming and technical books",
                },
                new Category
                {
                    Id = 3,
                    Name = "Accessories",
                    Description = "Everyday computer accessories",
                }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wireless Mouse",
                    Price = 450,
                    Quantity = 20,
                    Description = "Mouse mn 8er selk",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 2,
                    Name = "C++ Fundamentals",
                    Price = 350,
                    Quantity = 30,
                    Description = "ketab ll c++",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Headphones",
                    Price = 1200,
                    Quantity = 12,
                    Description = "Sama3at",
                    CategoryId = 3
                }
                );
            modelBuilder.Entity<Order>()
                .HasData(
                 new Order
                 {
                     Id = 1,
                     OrderDate = new DateTime(2026, 10, 01),
                     Status = "Completed",
                     TotalAmount = 800,
                     UserId = 1

                 },
                 new Order
                 {
                     Id = 2,
                     OrderDate = new DateTime(2026, 10, 12),
                     Status = "cancelled",
                     TotalAmount = 350,
                     UserId = 2

                 },
                 new Order
                 {
                     Id = 3,
                     OrderDate = new DateTime(2026, 10, 10),
                     Status = "Pending",
                     TotalAmount = 1200,
                     UserId = 3

                 }

                );

            modelBuilder.Entity<OrderItem>()
                .HasData(
                new OrderItem
                {
                    Id = 1,
                    Quantity = 1,
                    UnitPrice = 450,
                    OrderId = 1,
                    ProductId = 2,
                },
                new OrderItem
                {
                    Id = 2,
                    Quantity = 1,
                    UnitPrice = 350,
                    OrderId = 2,
                    ProductId = 3,
                },
                new OrderItem
                {
                    Id = 3,
                    Quantity = 1,
                    UnitPrice = 1200,
                    OrderId = 3,
                    ProductId = 2,
                }

                );

        }
    }
}
