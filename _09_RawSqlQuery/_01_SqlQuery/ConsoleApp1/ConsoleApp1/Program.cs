using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

/// SqlQuery allows executing raw SQL queries that map directly to entities.
/// 
///-> Use [FromSql] or [SqlQuery] to execute raw SQL and map results to entities.
/// 
/// 
/// 

class Program
{
   public static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         // FromSql +ef 7.0
         // FromSqlInterpolated ef 3.0
         // FromSqlRaw ef 3.0

         var courses =
             context.Courses.FromSql($"SELECT * FROM dbo.Courses");

         var coursesv2 =
           context.Courses.FromSqlInterpolated($"SELECT * FROM dbo.Courses");

         var coursesv3 =
          context.Courses.FromSqlRaw("SELECT * FROM dbo.Courses");

         foreach (var c in coursesv3)
         {
            Console.WriteLine($"{c.CourseName} ({c.HoursToComplete})");
         }

      }
      Console.ReadKey();
   }
}