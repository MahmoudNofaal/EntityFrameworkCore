
using ConsoleApp1.Data;

namespace ConsoleApp1;

/// Tracking Vs No Tracking
/// Tracking: EfCore tracks entities, enable change detection for updates (that is default behavior).
/// No-Tracking: Entities are not tracked, improving performance for read-only queries.
/// 
/// -> Use [AsNoTracking()] to disable tracking.
/// -> Tracked entities are stored in the [DbContext] change tracker, which monitors changes
///    for [SaveChanges()];
/// -> No-tracking queries are faster and use less memory, ideal for read-only queries
/// 

internal class Program
{
   public static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         var section = context.Sections.FirstOrDefault(x => x.Id == 1);

         Console.WriteLine("before changing tracked object");

         Console.WriteLine(section.SectionName);

         section.SectionName = "this is a new section name";

         context.SaveChanges();

         section = context.Sections.FirstOrDefault(x => x.Id == 1);

         Console.WriteLine("after bein changed");

         Console.WriteLine(section.SectionName);
      }


      //using (var context = new AppDbContext())
      //{
      //    var section = context.Sections.AsNoTracking().FirstOrDefault(x => x.Id == 1);

      //    Console.WriteLine("before changing tracked object");

      //    Console.WriteLine(section.SectionName); // BlaBla

      //    section.SectionName = "01A51C05";

      //    context.SaveChanges();

      //    section = context.Sections.FirstOrDefault(x => x.Id == 1);

      //    Console.WriteLine("after bein changed");

      //    Console.WriteLine(section.SectionName);
      //}

   }
}
