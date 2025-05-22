using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations
{
    public class SectionDetailsConfiguration : IEntityTypeConfiguration<SectionDetails>
    {
        public void Configure(EntityTypeBuilder<SectionDetails> builder)
        {
            builder.HasNoKey();
        }
    }
}
