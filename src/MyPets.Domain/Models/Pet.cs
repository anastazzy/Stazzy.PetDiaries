using MyPets.Domain.Models.PetProperties;

namespace MyPets.Domain.Models;

public class Pet : BaseModel
{
    // common data
    public Guid Id { get; set; }
    public string Name { get; set; }
    public PetsType Type { get; set; }
    public string? Breed { get; set; } // TODO: в зависимости от типа животного подставлять enum породы
    public DateTimeOffset? Birthday { get; set; }
    public GenderType? Gender { get; set; }
    public string? AnimalId { get; set; }
    
    // health
    public List<PetHealthPropertyInMoment>? HealthHistory { get; set; }
    
    public TimeMode? WalkingMode { get; set; }
    
    public List<User>? Users { get; set; }
    public List<Food>? Foods { get; set; }
    public List<UserEvent>? Events { get; set; }
}