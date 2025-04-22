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
}