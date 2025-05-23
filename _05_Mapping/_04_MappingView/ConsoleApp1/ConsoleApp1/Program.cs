using ConsoleApp1.Data;

namespace ConsoleApp1;

/// Mapping views
///- allows us to treat database views (read-only queries) as entities in EF Core,
///  enabling LINQ queries on complex data.
///  

internal class Program
{
   static void Main(string[] args)
   {
      var context = new AppDbContext();
      foreach (var item in context.OrderWithDetails)
      {
         Console.WriteLine(item);
      }

   }

}

