using ConsoleApp1.Data;

namespace ConsoleApp1;

/// Using Grouping Configuration:
/// [organizes Fluent API settings into separate classes to keep DbContext clean and maintainable.]
/// 
/// -> Instead of putting all Fluent API code in OnModelCreating,
///    we create IEntityTypeConfiguration<T> classes for each entity to define its configurations.
///    
/// When to Use:
/// Ideal for large projects with complex models or when we want to separate configuration logic.
/// 

internal class Program
{
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

