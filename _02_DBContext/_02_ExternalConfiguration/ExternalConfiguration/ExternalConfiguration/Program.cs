using ExternalConfiguration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExternalConfiguration;

internal class Program
{
   /// External Configuration
   /// * It means setting up our DbContext outside the class, like telling which database to
   ///   use or where to find the connection string.
   ///   


   static void Main(string[] args)
   {

      // confugure DbContext on Program.cs
      var configuration = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json")
                             .Build();

      var connectionString = configuration.GetSection("constr").Value;

      var optionBuilder = new DbContextOptionsBuilder().UseSqlServer(connectionString);

      var options = optionBuilder.Options;

      // test connection: by retrieving some data
      using (var _context = new AppDbContext(options))
      {
         foreach (var wallet in _context.Wallets)
         {
            Console.WriteLine(wallet);
         }

      }

   }

}

