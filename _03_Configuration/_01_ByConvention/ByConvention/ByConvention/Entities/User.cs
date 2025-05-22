using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByConvention.Entities;

public class User
{
   // Primary key convention [Id, id , ID] , [{Class}Id]
   public int UserId { get; set; }
   public string Username { get; set; }
}
