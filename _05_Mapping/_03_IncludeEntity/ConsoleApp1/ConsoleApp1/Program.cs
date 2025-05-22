using ConsoleApp1.Data;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1;

internal class Program
{
   static void Main(string[] args)
   {
      var context = new AppDbContext();

      //var ItemsInOrder1 = context
      //    .OrderDetails
      //    .Where(x => x.OrderId == 1); // compile time error


      var order1Details = context
           .Orders
           .Include(x => x.OrderDetails)
           .FirstOrDefault(x => x.Id == 1)
          .OrderDetails;

      Console.WriteLine($"Items Count In Order 1 = {order1Details.Count()}");

      var auditEntry = new AuditEntry { UserName = "spiderx", Action = "To read order count" };

      context.Set<AuditEntry>().Add(auditEntry);

      // context.SaveChanges(); // Error Invalid Object

   }

}

