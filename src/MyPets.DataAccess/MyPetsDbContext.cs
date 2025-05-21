using Microsoft.EntityFrameworkCore;
using MyPets.Domain.Models;

namespace MyPets.DataAccess;

public sealed class MyPetsDbContext : DbContext
{
    public MyPetsDbContext(DbContextOptions<MyPetsDbContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
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
        
        modelBuilder.Entity<Symptom>().HasData(
            new Symptom { Id = 1, Name = "Слезоточивость", Description = ""},
            new Symptom { Id = 2, Name = "Температура", Description = "Температура тела меньше 37,5 и больше 39" },
            new Symptom { Id = 3, Name = "Чесотка", Description = "" },
            new Symptom { Id = 4, Name = "Вялость", Description = "" },
            new Symptom { Id = 5, Name = "ОТказ от корма", Description = "" },
            new Symptom { Id = 6, Name = "Рвота", Description = "" },
            new Symptom { Id = 7, Name = "Диарея", Description = "" }
        );
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