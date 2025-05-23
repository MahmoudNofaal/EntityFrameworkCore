
namespace ConsoleApp1;

/// Scaffolding
///- It is a process of reverse-engineering a database schema to generate C# class,
///  navigation propertiy, and a DbContext class that maps to the database.
///  
/// Why it important:
/// Saves time when working with existing databases tp ensure models match the schema exactly.
///  
///  

internal class Program
{
   ///STEP01: Package Manager Console (PMC)
   ///        Tools => Nuget Package MAnager -> Package MAnager Console
   ///        
   ///STEP02: Package Manager Console (PMC) Tool
   ///        Install-Package Microsoft.EntityFrameworkCore.Tools
   ///        
   ///STEP03: Install Microsoft.EntityFrameworkCore.Design
   ///        
   ///STEP04: Install Provider Microsoft.EntityFrameworkCore.SqlServer
   ///        
   ///STEP05: Run Command (full)
   ///        Scaffold-DbContext '[ConnectionString]' [Provider]
   ///        
   /// * To make the scaffold [default]
   ///   -> ( Scaffold-DbContext 'Data Source = .; Initial Catalog = TechTalk;
   ///        Integrated Security = SSPI; TrustServerCertificate = True;'
   ///        Microsoft.EntityFrameworkCore.SqlServer )
   /// 
   /// * To make scaffold by data annotation
   ///   -> ( Scaffold-DbContext 'Data Source = .; Initial Catalog = TechTalk;
   ///        Integrated Security = SSPI; TrustServerCertificate = True;'
   ///        Microsoft.EntityFrameworkCore.SqlServer -DataAnnotations )
   ///   
   /// * To make the name of Context -> [AppDbContext]
   ///   -> ( Scaffold-DbContext 'Data Source = .; Initial Catalog = TechTalk;
   ///        Integrated Security = SSPI; TrustServerCertificate = True;'
   ///        Microsoft.EntityFrameworkCore.SqlServer -Context AppDbContext )
   ///   
   /// * To locate where AppDbContext and Entities to be ?
   ///   -> ( Scaffold-DbContext 'Data Source = .; Initial Catalog = TechTalk;
   ///        Integrated Security = SSPI; TrustServerCertificate = True;'
   ///        Microsoft.EntityFrameworkCore.SqlServer -Context AppDbContext
   ///        -ContextDir Data -OutputDir Entities )
   /// 

   


   static void Main(string[] args)
   {
      foreach (var item in new TechTalkContext().Speakers)
      {
         Console.WriteLine(item.FirstName + " " + item.LastName);
      }

   }

}

