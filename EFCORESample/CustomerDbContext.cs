using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCORESample
{
    public class CustomerDbContext :DbContext, ICustomerDbContext
    {
        public CustomerDbContext() { }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired(); //Not null
            modelBuilder.Entity<Customer>().Property(c => c.Contact).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.Address).IsRequired();

            modelBuilder.Entity<Customer>().Property(c => c.Email).HasDefaultValue("someone@gmail.com"); //default constraint
            modelBuilder.Entity<Customer>().HasAlternateKey("Contact"); //unique constraint

            //relationship among tables

            //modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders);

            ////composite primary key
            //modelBuilder.Entity<Customer>().HasKey(c => new { c.Id, c.Contact });

            //modelBuilder.Entity<Customer>().Property(c => c.Address).HasComputedColumnSql("Id + '-' + Name");

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
