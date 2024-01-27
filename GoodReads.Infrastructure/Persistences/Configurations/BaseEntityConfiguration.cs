using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GoodReads.Core.Entities;

namespace GoodReads.Infrastructure.Persistences.Configurations;

internal abstract class BaseEntityConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
               .UseMySqlIdentityColumn();

        builder.Property(b => b.Active)
               .IsRequired();

        builder.Property(b => b.CreatedAt)
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(b => b.UpdatedAt)
               .HasColumnType("datetime")
               .IsRequired();
    }
}