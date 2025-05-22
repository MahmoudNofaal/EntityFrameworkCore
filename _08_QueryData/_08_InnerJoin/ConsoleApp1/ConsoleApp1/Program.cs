using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

internal class Program
{
   static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         // query syntax

         //var resultQuerySyntax = (from c in context.Courses.AsNoTracking()
         //              join s in context.Sections.AsNoTracking()
         //                    on c.Id equals s.CourseId
         //              select new
         //              {
         //                  c.CourseName,
         //                  DateRange = s.DateRange.ToString(),
         //                  TimeSlot = s.TimeSlot.ToString()
         //              }).ToList();

         // method syntax
         var resultMethodSyntax =
             context.Courses.AsNoTracking()
             .Join(context.Sections.AsNoTracking(),
                 c => c.Id,
                 s => s.CourseId,
                 (c, s) => new
                 {
                    c.CourseName,
                    DateRange = s.DateRange.ToString(),
                    TimeSlot = s.TimeSlot.ToString()
                 }
             ).ToList();

      }
   }
}
