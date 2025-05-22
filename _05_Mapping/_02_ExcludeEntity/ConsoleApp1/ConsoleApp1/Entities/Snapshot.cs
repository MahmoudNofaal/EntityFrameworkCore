using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities;

//[NotMapped] /// means that is ignored
public class Snapshot
{
   public DateTime LoadedAt => DateTime.Now;
   public string Version => Guid.NewGuid().ToString()[..8];

}
