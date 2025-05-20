using Microsoft.EntityFrameworkCore;
using MyPets.Domain.Models;

namespace MyPets.DataAccess;

public sealed class MyPetsDbContext : DbContext
{
    public MyPetsDbContext(DbContextOptions<MyPetsDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<Food> Foods { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<Symptom> Symptoms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(e => e.Pets)
            .WithMany(e => e.Users)
            .UsingEntity("UserPets");
        
        modelBuilder.Entity<Pet>()
            .HasMany(e => e.Foods)
            .WithMany(e => e.Pets)
            .UsingEntity("PetFoods");
        
        modelBuilder.Entity<User>()
            .HasMany(e => e.Events)
            .WithMany(e => e.Users)
            .UsingEntity("UserEvents");
        
        modelBuilder.Entity<Pet>()
            .HasMany(e => e.Events)
            .WithMany(e => e.Pets)
            .UsingEntity("PetEvents");
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