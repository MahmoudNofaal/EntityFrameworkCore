using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations;

internal class IndividualConfiguration : IEntityTypeConfiguration<Individual>
{
   public void Configure(EntityTypeBuilder<Individual> builder)
   {
      builder.ToTable("Individuals");
   }
}



















