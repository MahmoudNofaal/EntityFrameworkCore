using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data;

public class AppDbContext : DbContext
{

   public DbSet<Order> Orders { get; set; }
   public DbSet<OrderDetail> orderDetails { get; set; }
   public DbSet<Product> Products { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Product>()
                  .ToTable("Products", schema: "Inventory")
                  .HasKey(x => x.Id);

      //modelBuilder.Entity<Order>()
      //      .ToTable("Orders", schema: "Sales")
      //      .HasKey(x => x.Id);

      modelBuilder.Entity<OrderDetail>()
            .ToTable("OrderDetails", schema: "Sales")
            .HasKey(x => x.Id);

      /// we can use default schema as general and
      /// if there is any table with different schema he should configure it
      /// as .ToTable(tableName, schema: DifferentSchemaName)
      /// 
      //modelBuilder.HasDefaultSchema("Sales");

   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      var configuration = new ConfigurationBuilder()
         .AddJsonFile("appsettings.json")
         .Build();

      var constr = configuration.GetSection("constr").Value;

      optionsBuilder.UseSqlServer(constr);

   }

}

