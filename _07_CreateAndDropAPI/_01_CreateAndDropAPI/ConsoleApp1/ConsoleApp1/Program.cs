using ConsoleApp1.Data;
using System.Threading.Tasks;

namespace ConsoleApp1;

/// Create&Drop API in EFCore provides methods to create or delete a database programmatically
///-> Typically used in development, testing, or initializing scenarios
///-> Methods like [Database.EnsureCreated(), Database.EnsureDeleted()]
///-> EnsureCreated(): Creates the database if it doesnot exist, using the current model.
///   if the database exists, it do nothing.
///-> EnsureDeleted(): Drops the database if it exists.
///-> Not for Migrations: if you use migrations, avoid EnsureCreated().
///
///

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

