namespace ConsoleApp1.Entities;

public class DateRange
{
   public DateOnly StartDate { get; set; }
   public DateOnly EndDate { get; set; }

   public override string ToString()
   {
      return $"{StartDate.ToString("yyyy-MM-dd")} - {EndDate.ToString("yyyy-MM-dd")}";
   }
}
