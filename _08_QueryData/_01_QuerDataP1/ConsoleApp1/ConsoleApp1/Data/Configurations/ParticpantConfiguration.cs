﻿using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations;

public class ParticpantConfiguration : IEntityTypeConfiguration<Participant>
{
   public void Configure(EntityTypeBuilder<Participant> builder)
   {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedNever();

      builder.Property(x => x.FName)
          .HasColumnType("VARCHAR")
          .HasMaxLength(50).IsRequired();

      builder.Property(x => x.LName)
      .HasColumnType("VARCHAR")
      .HasMaxLength(50).IsRequired();

      // builder.UseTptMappingStrategy();

      builder.ToTable("Particpants");
   }
}
