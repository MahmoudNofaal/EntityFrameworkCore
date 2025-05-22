using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.Property(x => x.Author)
               .HasColumnType("VARCHAR")
               .HasMaxLength(50).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.ToTable("Books");
        }
    }
}
