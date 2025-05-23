using ConsoleApp1.Data;

namespace ConsoleApp1;

/// Using Fluent API: [offering more control than conventions or data annotations]
/// -> Use methods like HasKey, HasMany, or Property to define mappings,
///    relationships, and constraints.
///* When to Use:
///  Best for complex mappings, like defining relationships or specific settings.
///    

/*
1. ToTable("TableName")
- Specifies the database table name for an entity,

2. HasKey(e => e.Property)
- Defines the primary key for an entity

3. Property(e => e.Property)
- Configures a property’s mapping, such as column name, type, or constraints.

4. Ignore(e => e.Property)
- Excludes a property or class from being mapped to the database.

5. HasColumnName("ColumnName")
- Specifies the column name for a property, used within [Property()].

6. HasColumnType("Type")
- Specifies the database column type (ex: VARCHAR(50), DECIMAL(18,2)).

7. HasOne(e => e.Navigation).WithMany(e => e.Navigation)
- Configures a one-to-many relationship, specifying the navigation properties and foreign key.

8. HasMany(e => e.Navigation).WithOne(e => e.Navigation)
- Configures a many-to-one relationship, the inverse of HasOne.WithMany.

9. HasForeignKey(e => e.Property)
- Specifies the foreign key property for a relationship.

10. HasOne(e => e.Navigation).WithOne(e => e.Navigation)
- Configures a one-to-one relationship.

11. HasIndex(e => e.Property)
- Creates a database index on one or more properties, optionally unique.

12. IsRequired()
- Marks a property as non-nullable, requiring a value.

13. HasMaxLength(length)
- Specifies the maximum length for a string or byte array.

14. HasPrecision(precision, scale)
- Specifies the precision and scale for decimal properties (ex: DECIMAL(18,2)).

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
