using InternalConfiguration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalConfiguration.Data;


/// [ DbContext ]
/// Dbcontext instance represents a session with the database
/// and can be used to query and save instances of your entities.
/// 
/// DbContext is a combination of the Unit of Work and Repository Pattern
public class AppDbContext : DbContext
{

   public AppDbContext()
   {
      
   }


   /// DbSet a collection that represents all entities
   public DbSet<Wallet> Wallets { get; set; } = null!;

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      base.OnConfiguring(optionsBuilder);

      ///INTERNALLY CONFIGURATION
      // set the configuration
      var configuration = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json")
                             .Build();

      // get the connection string
      var connectionString = configuration.GetSection("constr").Value;

      optionsBuilder.UseSqlServer(connectionString);
      

   }

}


