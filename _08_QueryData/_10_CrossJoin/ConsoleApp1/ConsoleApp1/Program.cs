using ConsoleApp1.Data;

namespace ConsoleApp1;

internal class Program
{
   static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         // Query syntax

         // ربط كل مدرس مع كل قسم بغض النظر اذا كان يعطيه او لا
         //var sectionInstructorQuerySyntax =
         //        (from s in context.Sections // 200
         //         from i in context.Instructors // 100
         //         select new
         //         {
         //             s.SectionName,
         //             i.FullName
         //         }).ToList();


         //Console.WriteLine(sectionInstructorQuerySyntax.Count()); // 20000

         // method syntax
         var sectionInstructorMethodSyntax = context.Sections
          .SelectMany(
              s => context.Instructors,
              (s, i) => new { s.SectionName, i.FName }
          ).ToList();

         Console.WriteLine(sectionInstructorMethodSyntax.Count());

      }

   }

}

