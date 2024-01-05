using System.Reflection;

using Microsoft.EntityFrameworkCore;

using GoodReads.Domain.Entities;

namespace GoodReads.Infrastructure.Data;

public class GoodReadsDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    public GoodReadsDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}