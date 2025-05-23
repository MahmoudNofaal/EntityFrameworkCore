using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

/// Eager Loading: retrieve data in a single query using [Include()]
///- Load related entities along with the main entity using [Include()] or [ThenInclude()]
///  for nested relationships.
///-> EF Core generates a SQL JOIN to fetch related data in one query.
///-> Reduces multiple database roundtrips, improving performance for scenarios needing related data.
///
/// 

internal class Program
{
   static void Main(string[] args)
   {
      //using (var context = new AppDbContext())
      //{
      //    var sectionId = 1;

      //    var sectionQuery = context.Sections
      //        .Include(x => x.Participants)
      //        .Where(x => x.Id == sectionId);

      //    Console.WriteLine(sectionQuery.ToQueryString());


      //    var section = sectionQuery.FirstOrDefault();
      //    Console.WriteLine($"section: {section.SectionName}");
      //    Console.WriteLine($"--------------------");
      //    foreach (var participant in section.Participants)
      //        Console.WriteLine($"[{participant.Id}] {participant.FName} {participant.LName}");

      //}

      using (var context = new AppDbContext())
      {
         var sectionId = 1;

         var sectionQuery = context.Sections
             .Include(x => x.Instructor)
             .ThenInclude(x => x.Office)
             .Where(x => x.Id == sectionId);

         Console.WriteLine(sectionQuery.ToQueryString());


         var section = sectionQuery.FirstOrDefault();

         Console.WriteLine($"section: {section.SectionName} " +
             $"[{section.Instructor.FName} " +
             $"{section.Instructor.LName} " +
             $"({section.Instructor.Office.OfficeName})]");

      }

   }

}

