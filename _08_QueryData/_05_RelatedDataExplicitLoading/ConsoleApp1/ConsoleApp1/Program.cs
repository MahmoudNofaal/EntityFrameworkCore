
using ConsoleApp1.Data;

namespace ConsoleApp1;

internal class Program
{
   static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         var sectionId = 1;

         var section = context.Sections
             .FirstOrDefault(x => x.Id == sectionId);

         var query = context.Entry(section).Collection(x => x.Participants).Query();

         Console.WriteLine($"section: {section.SectionName}");
         Console.WriteLine($"--------------------");

         foreach (var participant in query)
            Console.WriteLine($"[{participant.Id}] {participant.FName} {participant.LName}");

      }

   }

}

