using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.Data.Configurations;

public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
{
   public void Configure(EntityTypeBuilder<Tweet> builder)
   {

      builder.ToTable("tblTweets");

   }

}

