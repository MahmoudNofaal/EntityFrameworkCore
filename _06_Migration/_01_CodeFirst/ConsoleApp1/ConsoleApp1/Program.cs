using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

internal class Program
{
   static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         foreach (var item in context.Sections.Include(x => x.Course))
         {
            Console.WriteLine($"Section: {item.SectionName}, " +
                $"Course {item.Course.CourseName}");
         }
      }


   }

}

