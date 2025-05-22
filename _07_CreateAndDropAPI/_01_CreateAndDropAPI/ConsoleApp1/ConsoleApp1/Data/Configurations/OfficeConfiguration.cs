using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations;

public class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
   public void Configure(EntityTypeBuilder<Office> builder)
   {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedNever();

      builder.Property(x => x.OfficeName)
          .HasColumnType("VARCHAR")
          .HasMaxLength(50).IsRequired();

      builder.Property(x => x.OfficeLocation)
       .HasColumnType("VARCHAR")
       .HasMaxLength(50).IsRequired();


      builder.ToTable("Offices");

   }
}



















