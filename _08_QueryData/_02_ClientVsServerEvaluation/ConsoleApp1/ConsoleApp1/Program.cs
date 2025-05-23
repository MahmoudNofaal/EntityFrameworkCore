using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

/// Server Evaluation: EfCore transalte LINQ to SQL for execution on the database (ex: where, orderby)
/// Client Evaluation: If LINQ expression cannot be transalted to SQL (ex: complexx C# logic), EfCore
///                    evaluates it in memory after fetching data.
///
///-> How it works: EfCore tries to translate the entire query to SQL. if any part fails, it
///                 fetch data and processed it on the client.
///


internal class Program
{
   public static void Main(string[] args)
   {
      //using (var context = new AppDbContext())
      //{
      //    var courseId = 1;

      //    var result = context.Sections
      //        .Where(x => x.CourseId == courseId)
      //        .Select(x => new
      //        {
      //            Id = x.Id,
      //            Section = x.SectionName
      //        });

      //    //DECLARE @__courseId_0 int = 1;
      //    //SELECT[s].[Id], [s].[SectionName] AS[Section]
      //    //FROM[Sections] AS[s]
      //    //WHERE[s].[CourseId] = @__courseId_0

      //    Console.WriteLine(result.ToQueryString());

      //    foreach (var item in result)
      //    {
      //        Console.WriteLine($"{item.Id} {item.Section}");
      //    }
      //}

      using (var context = new AppDbContext())
      {
         var courseId = 1;

         var result = context.Sections
             .Where(x => x.CourseId == courseId)
             .Select(x => new
             {
                x.Id,
                Section = x.SectionName.Substring(4),
                TotalDays = CalculateTotalDays(x.DateRange.StartDate, x.DateRange.EndDate)
             });

         //  SELECT [s].[Id], [s].[SectionName], [s].[StartDate], [s].[EndDate]
         //  FROM [Sections] AS [s]
         //  WHERE [s].[CourseId] = @__courseId_0
         Console.WriteLine(result.ToQueryString());

         foreach (var item in result)
         {
            Console.WriteLine($"{item.Id} {item.Section} ({item.TotalDays})");
         }
      }

   }

   private static int CalculateTotalDays(DateOnly startDate, DateOnly endDate)
   {
      return endDate.DayNumber - startDate.DayNumber; // 0001-01-01
   }
}
