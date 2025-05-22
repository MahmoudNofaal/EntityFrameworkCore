using InternalConfiguration.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace InternalConfiguration;

internal class Program
{
   static void Main(string[] args)
   {
      using (var _context = new AppDbContext())
      {
         foreach (var wallet in _context!.Wallets)
         {
            Console.WriteLine(wallet);
         }

      }

   }

}
