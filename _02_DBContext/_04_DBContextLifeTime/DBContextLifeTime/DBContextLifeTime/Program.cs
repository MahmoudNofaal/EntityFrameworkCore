using DBContextLifeTime.Data;
using DBContextLifeTime.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBContextLifeTime;

/// LifeTime of a DbContext is how long it exists in our app before being disposed.
/// - A DbContext trackes objects in memory. [it should be short life as creating for one task]
/// - Why (short life): keeping DbContext alive too long can lead to memory leaks, stale data
///   or performance issues.
///   
///* How it works?
///-> Dependency Injection creates a DbContext per HTTP request and dispose it when the request ends.
///


internal class Program
{
   static void Main(string[] args)
   {
      // confiugration
      var configuration = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build();

      var connectionString = configuration.GetSection("constr").Value;

      var optionBuilder = new DbContextOptionsBuilder().UseSqlServer(connectionString);

      var options = optionBuilder.Options;

      // till the closing bracket the DbContext instance will be disposed.
      using (var _context = new AppDbContext(options))
      {
         var w1 = new Wallet { Id = 5, Holder = "Ominaa", Balance = 5000m };
         _context.Wallets.Add(w1);

         var w2 = new Wallet { Id = 6, Holder = "Osama", Balance = 7000m };
         _context.Wallets.Add(w2);

         _context.SaveChanges();

      }// end, and terminate the connection to the database.

   }
}
