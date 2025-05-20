namespace MyPets.Domain.Models;

/// <summary>
///     Describes events for pets, include care and health procedures. One owner make create many events for all their
///     pets, and can share it`s for other users
/// </summary>
public class PetEvent
{
    public int Id { get; set; }
    
    public Guid PetId { get; set; }
    public Pet? Pet { get; set; }
    
    public int UserEventId { get; set; }
    public UserEvent? UserEvent { get; set; }
}