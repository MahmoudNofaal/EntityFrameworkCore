
using EF_Start.Data;
using EF_Start.Entities;

namespace EF_Start;

/// EFCore: is a lightweight, extensible, open-source, and cross platform
/// Object Relational Mapping(ORM) framework, developed by Microsoft for .NET application.
/// 
/// - EFCore serves as a bridge between our application object-oriented code and relational
///   database, allowing us to work with data using C# objects instead or writing raw sql queries.
/// 

/*
 * 
 What It Does?:
- Maps database tables to C# classes (entities).
- Supports LINQ for type-safe querying.
- Tracks changes and generates SQL for CRUD operations.
- Manages database schemas via migrations.
- Handles relationships (ex, one-to-many) and supports multiple
  databases (SQL Server, SQLite, PostgreSQL).


 */

internal class Program
{

   /*
    * The DbContext class is the core component of EF Core,
    * acting as a bridge between the domain classes (ex: Wallet) and the database.
    * It can:
    * - manages entity tracking
    * - database connections
    * - query execution
    * 
    * Defining a DbContext by subclassing DbContext and configuring it
    * to map entities to database tables.
    * 
    */
   static void Main(string[] args)
   {

      RetreiveData();
      //RetrieveSingleItem();
      //InsertData();
      //UpdateData();
      //DeleteData();
      //ImplementTransaction();

   }

   static void RetreiveData()
   {
      /// retrieve data
      /// use dispose to the DbContext
      /// 
      using (var _context = new AppDbContext())
      {

         foreach (var wallet in _context.Wallets)
         {
            Console.WriteLine(wallet);
         }

      }
   }

   static void RetrieveSingleItem()
   {
      var itemId = 2;

      using (var _context = new AppDbContext())
      {

         var item = _context.Wallets.FirstOrDefault(x => x.Id == itemId);

         Console.WriteLine(item);

      }

   }

   static void InsertData()
   {
      var wallet03 = new Wallet
      {
         Holder = "Omaar",
         Balance = 23000m
      };

      using (var _context = new AppDbContext())
      {
         // here the addition operation is happend on the memory
         _context.Wallets.Add(wallet03);

         // we use SaveChanges to save it in the database
         _context.SaveChanges();

         // print all items again to sure the item is added successfully!
         foreach (var wallet in _context.Wallets)
         {
            Console.WriteLine(wallet);
         }
      }

   }

   static void UpdateData()
   {

      using (var _context = new AppDbContext())
      {
         // update wallet (Id = 2, Marwa) Balance=15000 to Balance=18000

         var walletOfMarwa = _context.Wallets.Find(2); // find wallet of Id = 2

         walletOfMarwa.Balance += 3000m;

         _context.Wallets.Update(walletOfMarwa);

         _context.SaveChanges();

         Console.WriteLine(walletOfMarwa);

      }

   }

   static void DeleteData()
   {

      using (var _context = new AppDbContext())
      {
         // delete last wallet

         var walletToDelete = _context.Wallets.OrderBy(x => x).LastOrDefault();

         _context.Wallets.Remove(walletToDelete);

         _context.SaveChanges();

         // print all items again to sure the item is deleted successfully!
         foreach (var wallet in _context.Wallets)
         {
            Console.WriteLine(wallet);
         }

      }

   }

   static void ImplementTransaction()
   {
      using (var _context = new AppDbContext())
      {
         using (var transaction = _context.Database.BeginTransaction())
         {
            /// transfer 500$ from Ahmed id=1 to Marwa id=2
            /// 
            var fromAhmedWallet = _context.Wallets.SingleOrDefault(x => x.Id == 1);
            var toMarwaWallet = _context.Wallets.SingleOrDefault(x => x.Id == 2);

            var amountToTransfer = 500m;

            // #operation 1: withdraw 500$ from walletAhmed
            fromAhmedWallet.Balance -= amountToTransfer;
            _context.SaveChanges();

            // #operation 2: deposite 500$ to walletMarwa
            toMarwaWallet.Balance += amountToTransfer;
            _context.SaveChanges();

            transaction.Commit();

         }

      }

   }

}
