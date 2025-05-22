namespace ConsoleApp1.Entities;

public class Review : Entity
{
   public string? Feedback { get; set; }

   public int CourseId { get; set; }

   public Course? Course { get; set; }

   public DateTime CreatedAt { get; set; }
}
