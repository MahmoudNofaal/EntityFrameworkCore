using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsingContextPooling.Data;

namespace UsingContextPooling;

/*
 Context Pooling
-> reuses DbContext instances to save time in high-traffic apps
-> use [AddDbContextPool<TContext>] instead of [AddDbContext]. EF Core manages the pool automatically.

* Reduces the time spent creating new [DbContext] instances, speeding up apps like
  a busy e-commerce API.
 
 */

internal class Program
{
   static void Main(string[] args)
   {
      var config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

      var connectionString = config.GetSection("constr").Value;

      var services = new ServiceCollection();

      services.AddDbContextPool<AppDbContext>(options =>
          options.UseSqlServer(connectionString)
      );

      IServiceProvider serviceProvider = services.BuildServiceProvider();

      using (var context = serviceProvider.GetService<AppDbContext>())
      {
         foreach (var wallet in context!.Wallets)
         {
            Console.WriteLine(wallet);
         }
      }

   }

}

