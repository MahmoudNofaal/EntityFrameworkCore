namespace ConsoleApp1.Entities;

public class Section : Entity
{
   public string? SectionName { get; set; }
   public int CourseId { get; set; }
   public Course? Course { get; set; }
   public int InstructorId { get; set; }
   public Instructor? Instructor { get; set; }
   public int ScheduleId { get; set; }
   public Schedule? Schedule { get; set; }
   public DateRange DateRange { get; set; } = new();
   public TimeSlot TimeSlot { get; set; } = new();
   public List<Participant> Participants { get; set; } = new List<Participant>();
}
