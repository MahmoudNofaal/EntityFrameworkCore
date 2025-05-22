using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities;

public class Order
{
   public int Id { get; set; }
   public string CustomerEmail { get; set; }
   public DateTime OrderDate { get; set; }
   public List<OrderDetail> OrderDetails { get; set; } = [];

}

