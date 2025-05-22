namespace ConsoleApp1.Entities;

public class TimeSlot
{
   public TimeSpan StartTime { get; set; }
   public TimeSpan EndTime { get; set; }

   public override string ToString()
   {
      return $"{StartTime.ToString("hh\\:mm")} - {EndTime.ToString("hh\\:mm")}";
   }
}

