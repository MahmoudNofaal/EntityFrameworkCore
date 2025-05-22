using ConsoleApp1.Data;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class Program
{
   static async Task Main(string[] args)
   {
      using (var _context = new AppDbContext())
      {
         // Database will be created if it does not exist
         await _context.Database.EnsureCreatedAsync();

         await Task.Delay(1000);

         // DAtabase will be deleted if it does exist
         await _context.Database.EnsureDeletedAsync();

      }

   }

}

