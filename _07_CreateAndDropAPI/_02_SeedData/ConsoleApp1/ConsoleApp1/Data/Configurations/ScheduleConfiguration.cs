﻿using ConsoleApp1.Data;
using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
   public void Configure(EntityTypeBuilder<Schedule> builder)
   {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedNever();

      // builder.Property(x => x.CourseName).HasMaxLength(255); // nvarchar(255)

      builder.Property(x => x.Title)
          .HasConversion(
               x => x.ToString(),
               x => (ScheduleEnum) Enum.Parse(typeof(ScheduleEnum), x)
          );

      builder.ToTable("Schedules");

      builder.HasData(SeedData.LoadSchedules());

   }
}



















