using Microsoft.EntityFrameworkCore;
using MyPets.Domain.Models;

namespace MyPets.DataAccess;

public class MyPetsDbContext(DbContextOptions<MyPetsDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}