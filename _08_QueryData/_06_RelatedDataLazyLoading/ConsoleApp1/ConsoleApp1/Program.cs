
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

         foreach (var participant in section.Participants)
         {
            Console.WriteLine($"[{participant.Id}] {participant.FName} {participant.LName}");
         }

      }

   }

}

