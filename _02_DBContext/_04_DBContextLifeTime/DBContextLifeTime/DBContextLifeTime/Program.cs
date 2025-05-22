using DBContextLifeTime.Data;
using DBContextLifeTime.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBContextLifeTime
{
   internal class Program
   {
      static void Main(string[] args)
      {
         var configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();

         var connectionString = configuration.GetSection("constr").Value;

         var optionBuilder = new DbContextOptionsBuilder().UseSqlServer(connectionString);

         var options = optionBuilder.Options;

         using (var _context = new AppDbContext(options))
         {
            var w1 = new Wallet { Id = 5, Holder = "Ominaa", Balance = 5000m };
            _context.Wallets.Add(w1);

            var w2 = new Wallet { Id = 6, Holder = "Osama", Balance = 7000m };
            _context.Wallets.Add(w2);

            _context.SaveChanges();

         }

      }
   }
}
