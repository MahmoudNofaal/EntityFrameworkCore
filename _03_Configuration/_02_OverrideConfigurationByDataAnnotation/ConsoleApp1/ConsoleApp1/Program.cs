
using ConsoleApp1.Data;

namespace ConsoleApp1;

/// Data Annotations: [attributes we add to our models to overiide conventions]
/// -> like [Key], [Required], [Table], we use to customize mapping directly in our classes
/// 

/*
1. [Table("TableName")]
- Specifies the database table name for an entity

2. [Column("ColumnName")]
- Specifies the column name for a property

3. [NotMapped]
- Excludes a property or class from being mapped to the database.

4. [Key]
- Marks a property as the primary key

5. [ForeignKey("NavigationProperty")]
- Specifies the foreign key property for a navigation property, clarifying the relationship.

6. [Required]
- Marks a property as non-nullable, requiring a value in the database.

7. [MaxLength(length)] / [StringLength(length)]
- Specifies the maximum length of a string or byte array, creating a database constraint
  (ex: VARCHAR(100)).

8. [MinLength(length)]
- Specifies the minimum length for a string or array, used for validation.

9. [Range(min, max)]
- Restricts a numeric property to a range of values.

10. [RegularExpression("pattern")]
- Validates a string property against a regular expression.

 */

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

