using Concurrency.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency.Data;


public class AppDbContext : DbContext
{

   public AppDbContext(DbContextOptions options) : base(options)
   {
      
   }


   /// DbSet a collection that represents all entities
   public DbSet<Wallet> Wallets { get; set; } = null!;

}


