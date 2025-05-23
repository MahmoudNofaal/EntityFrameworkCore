using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsingDependencyInjection.Data;

namespace UsingDependencyInjection;

/// Dependency Injection(DI)
/// lets automatically creates and dispose DbContext instances for us.
/// -> We reigster the DbContext in PRogram.cs

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

