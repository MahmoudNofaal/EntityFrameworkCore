using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsingContextFactory.Data;

namespace UsingContextFactory;

internal class Program
{
   static void Main(string[] args)
   {
      var configuration = new ConfigurationBuilder()
                             .AddJsonFile("appsettings.json")
                             .Build();

      var connectionString = configuration.GetSection("constr").Value;

      var services = new ServiceCollection();

      services.AddDbContextFactory<AppDbContext>(options =>
      {
         options.UseSqlServer(connectionString);
      });

      IServiceProvider serviceProvider = services.BuildServiceProvider();

      var contextFactory = serviceProvider.GetService<IDbContextFactory<AppDbContext>>();

      using (var _context = contextFactory!.CreateDbContext())
      {
         foreach (var wallet in _context!.Wallets)
         {
            Console.WriteLine(wallet);
         }

      }

   }

}

