using ExternalConfiguration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExternalConfiguration;

internal class Program
{
   /// External Configuration
   /// * It means invloves loading the connection string from appsettings.json outside
   ///   the DbContext code.
   /// * Useful for 


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
         foreach (var wallet in _context.Wallets)
         {
            Console.WriteLine(wallet);
         }

      }


   }

}
