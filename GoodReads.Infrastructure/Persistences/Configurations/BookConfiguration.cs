using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GoodReads.Domain.Books;

namespace GoodReads.Infrastructure.Persistences.Configurations;

internal class BookConfiguration : BaseEntityConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder.HasIndex(b => b.Isbn)
               .IsUnique();

        builder.Property(b => b.Isbn)
               .HasMaxLength(13)
               .IsRequired();

        builder.Property(b => b.Title)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(b => b.Description)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(b => b.Author)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(b => b.Publisher)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(b => b.Genre)
               .IsRequired();

        builder.Property(b => b.PublicationYear)
               .IsRequired();

        builder.Property(b => b.PrintLength)
               .IsRequired();

        builder.Property(b => b.AverageRating)
               .HasColumnType("numeric(3,1)")
               .IsRequired();

        builder.Property(b => b.NumberOfRatings)
               .IsRequired();

        builder.Property(b => b.CoverImage)
               .HasMaxLength(255)
               .IsRequired();

        builder.HasMany(b => b.Ratings)
               .WithOne(r => r.Book)
               .HasForeignKey(r => r.BookId)
               .IsRequired();
    }
}
