using Microsoft.EntityFrameworkCore;
using MyPets.Domain.Models;

namespace MyPets.DataAccess;

public sealed class MyPetsDbContext : DbContext
{
    public MyPetsDbContext(DbContextOptions<MyPetsDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e is { Entity: BaseModel, State: EntityState.Added or EntityState.Modified });

        foreach (var entityEntry in entries)
        {
            ((BaseModel) entityEntry.Entity).UpdatedDate = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseModel) entityEntry.Entity).CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }
}