﻿namespace ConsoleApp1.Entities;

public class Section
{
   public int Id { get; set; }
   public string SectionName { get; set; }
   public int CourseId { get; set; }
   public Course Course { get; set; }
   public int? InstructorId { get; set; }
   public Instructor? Instructor { get; set; }
   public int ScheduleId { get; set; }
   public Schedule Schedule { get; set; }
   public TimeSlot TimeSlot { get; set; }
   public ICollection<Participant> Participants { get; set; } = new List<Participant>();
}

