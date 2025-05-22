using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities;

public class SectionSchedule
{
   public int Id { get; set; }
   public int SectionId { get; set; }
   public int ScheduleId { get; set; }

   public TimeSpan StartTime { get; set; }
   public TimeSpan EndTime { get; set; }
}
