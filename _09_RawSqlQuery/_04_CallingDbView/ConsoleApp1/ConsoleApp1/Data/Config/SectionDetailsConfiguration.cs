using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Config
{
    public class SectionDetailsConfiguration : IEntityTypeConfiguration<SectionDetails>
    {
        public void Configure(EntityTypeBuilder<SectionDetails> builder)
        {
            builder.HasNoKey();
        }
    }

    public class CourseOverviewConfiguration : IEntityTypeConfiguration<CourseOverview>
    {
        public void Configure(EntityTypeBuilder<CourseOverview> builder)
        {
            builder.HasNoKey();
            builder.ToView("CourseOverview");
        }
    }
}
