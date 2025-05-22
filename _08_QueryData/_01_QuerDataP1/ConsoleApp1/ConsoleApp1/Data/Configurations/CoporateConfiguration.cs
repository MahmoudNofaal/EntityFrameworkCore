using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations;

public class CoporateConfiguration : IEntityTypeConfiguration<Corporate>
{
   public void Configure(EntityTypeBuilder<Corporate> builder)
   {
      builder.ToTable("Coporates");
   }

}

