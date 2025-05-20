namespace MyPets.Domain.Models;

/// <summary>
///     Describes time and relations for pet and owners
/// </summary>
public class UserPet
{
    public int Id { get; set; }

    public Guid PetId { get; set; }
    public Pet? Pet { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public bool IsOwner { get; set; }
    public DateTimeOffset StartRelationships { get; set; }
    public DateTimeOffset EndRelationships { get; set; }
    public string? UserNotes { get; set; }
}