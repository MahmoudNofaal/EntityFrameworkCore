using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

/// Split queries: split a single LINQ query with multiple [Include()] calls into separate
///                SQL queries to avoid complex joins.
///
///-> Instead of generating a single SQL query with multiple JOINs
///-> Use AsSplitQuery() to instruct EF Core to split the query.
///
///
///
///

internal class Program
{
   static void Main(string[] args)
   {
      //using (var context = new AppDbContext())
      //{
      //   // proper projection (select) reduce network traffic
      //   // and reduce the effect on app performance
      //   var coursesProjection = context.Courses.AsNoTracking()
      //       .Select(c => new
      //       {
      //          CourseId = c.Id,
      //          CourseName = c.CourseName,
      //          Hours = c.HoursToComplete,
      //          Section = c.Sections.Select(s =>
      //          new
      //          {
      //             SectionId = s.Id,
      //             SectionName = s.SectionName,
      //             DateRate = s.DateRange.ToString(),
      //             TimeSlot = s.TimeSlot.ToString()
      //          }),
      //          Reviews = c.Reviews.Select(r =>
      //          new
      //          {
      //             FeedBack = r.Feedback,
      //             CreateAt = r.CreatedAt
      //          })
      //       })
      //       .ToList();

      //}

      using (var context = new AppDbContext())
      {
         //var courses1 = context.Courses.Include(x => x.Sections)
         //                              .Include(x => x.Reviews)
         //                              .AsSplitQuery() // explicit
         //                              .ToList();

         //var courses2 = context.Courses.Include(x => x.Sections)
         //                               .Include(x => x.Reviews) // split by config
         //                               .ToList();

         var courses3 = context.Courses.Include(x => x.Sections)
                                       .Include(x => x.Reviews) // split by config
                                       .AsSingleQuery()
                                       .ToList();
      }

   }

}

