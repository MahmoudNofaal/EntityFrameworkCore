using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsingDependencyInjection.Data;

namespace UsingDependencyInjection;

internal class Program
{
   static void Main(string[] args)
   {
      var configuration = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json")
                             .Build();

      var connectionString = configuration.GetSection("constr").Value;

      var services = new ServiceCollection();

      services.AddDbContext<AppDbContext>(options =>
      {
         options.UseSqlServer(connectionString);
      });

      IServiceProvider serviceProvider = services.BuildServiceProvider();

      using (var _context = serviceProvider.GetService<AppDbContext>())
      {
         foreach (var wallet in _context!.Wallets)
         {
            Console.WriteLine(wallet);
         }

      }


   }

}

