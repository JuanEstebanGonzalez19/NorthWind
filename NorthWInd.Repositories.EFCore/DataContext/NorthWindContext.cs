using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repositories.EFCore.DataContext
{
    public class NorthWindContext: DbContext
    {
        public NorthWindContext(
            DbContextOptions<NorthWindContext> options) : 
            base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating
            (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Customer>() 
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Order>()
               .Property(o => o.ShipAddress)
               .IsRequired()
               .HasMaxLength(60);
            modelBuilder.Entity<Order>()
               .Property(o => o.ShipCity)
               .IsRequired()
               .HasMaxLength(15);
            modelBuilder.Entity<Order>()
              .Property(o => o.ShipCountry)
              .IsRequired()
              .HasMaxLength(15);
            modelBuilder.Entity<Order>()
              .Property(o => o.ShipPostalCode)
              .IsRequired()
              .HasMaxLength(10);

            modelBuilder.Entity<OrderDetail>()
              .HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<OrderDetail>()
              .Property(od => od.UnitPrice)
              .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany().
                HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<OrderDetail>()
                .HasOne<Customer>()
                .WithMany().
                HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, Name = "Chai" },
                new Product { Id = 2, Name = "Chang" },
                new Product { Id = 3, Name = "Anissed Syrup" }
                );
            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { Id = "AFLKI", Name = "Alfreds F." },
                new Customer { Id = "ANATR", Name = "Ana Trujillo" },
                new Customer { Id = "ANTON", Name = "Antonio Moreno" }
                );

        }
    }

}
