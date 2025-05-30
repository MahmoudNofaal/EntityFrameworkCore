﻿using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
   public void Configure(EntityTypeBuilder<Section> builder)
   {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedNever();

      // builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)

      builder.Property(x => x.SectionName)
          .HasColumnType("VARCHAR")
          .HasMaxLength(255).IsRequired();

      builder.HasOne(x => x.Course)
          .WithMany(x => x.Sections)
          .HasForeignKey(x => x.CourseId)
          .IsRequired();

      builder.HasOne(x => x.Instructor)
          .WithMany(x => x.Sections)
          .HasForeignKey(x => x.InstructorId)
          .IsRequired(false);

      builder.OwnsOne(x => x.TimeSlot, ts =>
      {
         ts.Property(p => p.StartTime).HasColumnType("time(0)").HasColumnName("StartTime").IsRequired();
         ts.Property(p => p.EndTime).HasColumnType("time(0)").HasColumnName("EndTime").IsRequired();
      });

      builder.OwnsOne(x => x.DateRange, ts =>
      {
         ts.Property(p => p.StartDate).HasColumnType("date").HasColumnName("StartDate").IsRequired();
         ts.Property(p => p.EndDate).HasColumnType("date").HasColumnName("EndDate").IsRequired();
      });

      builder.HasOne(c => c.Schedule)
          .WithMany(x => x.Sections)
          .HasForeignKey(x => x.ScheduleId)
          .IsRequired();

      builder.HasMany(c => c.Participants)
    .WithMany(x => x.Sections)
    .UsingEntity<Enrollment>();

      builder.ToTable("Sections");
   }
}
