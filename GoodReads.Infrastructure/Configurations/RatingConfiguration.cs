using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using GoodReads.Domain.Entities;

namespace GoodReads.Infrastructure.Configurations;

internal class RatingConfiguration : BaseEntityConfiguration<Rating>
{
    public override void Configure(EntityTypeBuilder<Rating> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Grade)
               .IsRequired();

        builder.Property(b => b.Description)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(b => b.UserId)
               .IsRequired();

        builder.Property(b => b.BookId)
               .IsRequired();    
    }
}