using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
   public void Configure(EntityTypeBuilder<Comment> builder)
   {

      builder.ToTable("tblComments");

   }

}

