using MyPets.Domain.Models.PetProperties;

namespace MyPets.Domain.Models;

public class Food : BaseModel
{
    public int Id { get; set; }
    public string? FeedBrand { get; set; }
    public string? Structure { get; set; }
    public PetsType? TargetAnimalType { get; set; }
    public string? TargetAge { get; set; } // enum 
    public string? Notes { get; set; }
    
    public List<Pet>? Pets { get; set; }
}