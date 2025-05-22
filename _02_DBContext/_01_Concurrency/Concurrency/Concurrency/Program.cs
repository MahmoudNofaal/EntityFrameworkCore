using Concurrency.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Concurrency;

internal class Program
{
   /// Concurrency refers to:
   /// * It handles situations where multiple users or processes attempt to
   ///   modify the same data simulationeusly
   /// * EFCore uses optimistic concurrency by default.

   static void Main(string[] args)
   {
      // *First: Load configurations
      var configuration = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json")
                             .Build();

      // get the connection string
      var connectionString = configuration.GetSection("constr").Value;

      // build options
      var options = new DbContextOptionsBuilder<AppDbContext>()
                       .UseSqlServer(connectionString)
                       .Options;

      // simulate two users updating the same wallet
      using (var _context01 = new AppDbContext(options))
      using (var _context02 = new AppDbContext(options))
      {
         // get the wallet to be update (id=1)
         var firstWallet01 = _context01.Wallets.First(x => x.Id == 1);
         var firstWallet02 = _context02.Wallets.First(x => x.Id == 1);

         // updated wallet01
         firstWallet01.Balance += 100;

         // save the updated wallet
         _context01.SaveChanges();
         Console.WriteLine($"_context01 updated wallet: {firstWallet01}");

         // updated wallet02
         firstWallet02.Balance += 100;

         // now try to save new second updated to the wallet
         try
         {
            _context02.SaveChanges(); // it will throw an exception
         }
         catch (Exception ex)
         {
            Console.WriteLine("Concurrency conflict detected: " + ex.Message);

            // Resolve conflict
            _context02.Entry(firstWallet02).Reload();

            firstWallet02.Balance += 200;

            _context02.SaveChanges()
               ;
            Console.WriteLine("Conflict resolved, new balance: " + firstWallet02);

         }

      }

   }

}
