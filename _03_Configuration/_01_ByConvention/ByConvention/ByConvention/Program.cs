using ByConvention.Data;

namespace ByConvention;

/// Configuration in EFCOre determines how our models be translated in the database
/// 
/// By Convention [EF Core assumes defaults]
/// -> Class names become table names (Book -> Book table)
/// -> Properties become columns with matching names and types.
/// -> PRoperties named Id or [classname]Id (ex: CategoryId) are primary key.
/// -> Properties referencing another class (Category Category) become foreign keys
/// 
///  public int Id { get; set; } // Primary key by convention
///  public int CategoryId { get; set; } // Foreign key by convention
///  public Category Category { get; set; } // Navigation property
///  public List<Book> Books { get; set; } // Navigation property
/// 
/// * When to Use:
///- Ideal for quick simple apps where defaults are sufficient.
/// 
/// 




internal class Program
{
   
   /// 1) DbSet property name match table name.
   /// 2) Promary Key (PK) (id, Id, ID) or ([class]Id).
   /// 3) Column name match property name.

   static void Main(string[] args)
   {
      using (var context = new AppDbContext())
      {
         Console.WriteLine("-------- Users ------------");
         Console.WriteLine();
         foreach (var user in context.Users)
         {
            Console.WriteLine(user.Username);
         }
         Console.WriteLine();

         Console.WriteLine("-------- Tweets -----------");
         Console.WriteLine();
         foreach (var tweet in context.Tweets)
         {
            Console.WriteLine(tweet.TweetText);
         }
         Console.WriteLine();

         Console.WriteLine("-------- Comments ----------");
         Console.WriteLine();
         foreach (var comment in context.Comments)
         {
            Console.WriteLine(comment.CommentText);
         }

      }

   }

}

