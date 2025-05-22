using DBContextLifeTime.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContextLifeTime.Data;


/// [ DbContext ]
/// Dbcontext instance represents a session with the database
/// and can be used to query and save instances of your entities.
/// 
/// DbContext is a combination of the Unit of Work and Repository Pattern
public class AppDbContext : DbContext
{

   public AppDbContext(DbContextOptions options) : base(options)
   {
      
   }


   /// DbSet a collection that represents all entities
   public DbSet<Wallet> Wallets { get; set; } = null!;

}


