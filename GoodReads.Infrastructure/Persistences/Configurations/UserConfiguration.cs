using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GoodReads.Domain.Users;

namespace GoodReads.Infrastructure.Persistences.Configurations;

internal class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(b => b.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.OwnsOne(b => b.Email,
            email =>
            {
                email.Property(b => b.Address)
                     .HasColumnName("Email")
                     .HasMaxLength(100)
                     .IsRequired();

                email.HasIndex(b => b.Address)
                     .IsUnique();
            });

        builder.HasMany(b => b.Ratings)
               .WithOne(r => r.User)
               .HasForeignKey(r => r.UserId)
               .IsRequired();
    }
}
