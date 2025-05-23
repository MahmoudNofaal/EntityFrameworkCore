using InternalConfiguration.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace InternalConfiguration;

///* Internal Configuration
///  is about defining our classes map to database tables, columns, and relations inside
///  the DbContext.
///  

/*
 In internal configuration
-> we use OnModelingCreating method of DataAnnotations to tell EF Core how our models relate
   to the database
-> we use the FluentAPI in OnModelCreating for complex (relations) or DataAnnotaions for simple
   rules directly in model classes.

 */

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
