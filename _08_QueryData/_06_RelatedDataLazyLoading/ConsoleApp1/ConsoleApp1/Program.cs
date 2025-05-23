
using ConsoleApp1.Data;

namespace ConsoleApp1;

/// Lazy Loading: loads related data automaticlly when accessed, without explicit [Include()]
///- Related data is fetched onDemand when a navigation property is accessed,
///  using proxies or explicit configuration.
///  
///-> Requires enabling lazy loading via Microsoft.EntityFrameworkCore.Proxies or
///   manual configuration.
///-> Simplifies code by loading related data automatically.
/// 

internal class Program
{
   static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         var sectionId = 1;

         var section = context.Sections
             .FirstOrDefault(x => x.Id == sectionId);

         foreach (var participant in section.Participants)
         {
            Console.WriteLine($"[{participant.Id}] {participant.FName} {participant.LName}");
         }

      }

   }

}

