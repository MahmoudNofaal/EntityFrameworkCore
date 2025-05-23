using ConsoleApp1.Data;

namespace ConsoleApp1;

/// Exclude Entity
///- It means prevents them from being mapped to the database
///
///-> we use attributes or FluentAPI yo execlude entire class or specific properties
///   from database.
///-> it benefite to keep database clean and has the only things important.

internal class Program
{
   static void Main(string[] args)
   {
      var context = new AppDbContext();
      foreach (var product in context.Products)
      {
         Console.WriteLine($"{product.Name} \t\n...... loaded at " +
             $"[{product.Snapshot.LoadedAt.ToString("dd-MM-yyyy hh:mm")}]" +
             $"\nVersion: {product.Snapshot.Version}\n");
      }

   }

}

