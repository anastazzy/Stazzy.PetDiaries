using System.ComponentModel.DataAnnotations;

namespace MyPets.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }

    public User(string name, string email, string passwordHash, string salt, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Salt = salt;
    }
}