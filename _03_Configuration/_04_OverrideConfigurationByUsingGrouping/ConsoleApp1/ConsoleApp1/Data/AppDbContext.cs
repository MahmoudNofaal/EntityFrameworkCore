using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ConsoleApp1.Entities;
using ConsoleApp1.Data.Configurations;

namespace ConsoleApp1.Data;

public class AppDbContext : DbContext
{
   public DbSet<User> Users { get; set; } = null!;
   public DbSet<Tweet> Tweets { get; set; } = null!;
   public DbSet<Comment> Comments { get; set; } = null!;

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      base.OnConfiguring(optionsBuilder);

      var config = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json")
                      .Build();

      var connectionString = config.GetSection("constr").Value;

      optionsBuilder.UseSqlServer(connectionString);
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      /// INDIVIDUAL CALL FOR THE CONFIGURATION
      //modelBuilder.ApplyConfiguration(new UserConfiguration());
      //modelBuilder.ApplyConfiguration(new TweetConfiguration());
      //modelBuilder.ApplyConfiguration(new CommentConfiguration());

      ///APPLY CONFIGURATION USING ASSEMBLY
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);


   }

}

