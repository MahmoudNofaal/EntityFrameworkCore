using ConsoleApp1.Data;

namespace ConsoleApp1;

/// 

internal class Program
{
   static void Main(string[] args)
   {
      var context = new AppDbContext();
      foreach (var product in context.Products)
      {
         Console.WriteLine(product.Name);
      }

   }

}

