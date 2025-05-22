
using ConsoleApp1.Data;

namespace ConsoleApp1;

internal class Program
{
   static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         // •  Ins#1
         //         S1, S2, s3
         // •  Ins#2
         //         S5, S2, s1

         // Query syntax

         //var instructorSections =
         //    from s in context.Sections
         //    group s by s.Instructor
         //    into g
         //    select new
         //    {
         //        Key = g.Key,
         //        Sections = g.ToList()
         //    };

         //foreach (var item in instructorSections)
         //{
         //    Console.WriteLine(item.Key.FullName);
         //    foreach (var section in item.Sections)
         //    {
         //        Console.WriteLine(section.SectionName);
         //    }
         //}


         //var instructorSections =
         //    from s in context.Sections
         //    group s by s.Instructor
         //    into g
         //    select new
         //    {
         //        Key = g.Key,
         //        TotalSections = g.Count()
         //    };



         // method syntax
         var instructorSections =
             context.Sections.GroupBy(x => x.Instructor)
             .Select(x => new
             {
                x.Key,
                TotalSections = x.Count()
             });


         foreach (var item in instructorSections)
         {
            Console.WriteLine($"{item.Key.FName} " +
                $"==> Total Sections #[{item.TotalSections}]");
         }


      }

   }

}

