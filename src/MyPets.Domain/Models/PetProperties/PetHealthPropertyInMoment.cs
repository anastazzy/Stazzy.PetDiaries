namespace MyPets.Domain.Models.PetProperties;

public class PetHealthPropertyInMoment : BaseModel
{
    public Guid Id { get; set; }
    public Guid PetId { get; set; }
    
    public double Weight { get; set; }
    public double Height { get; set; }
    public List<Symptom>? Symptoms { get; set; }
    public string? Notes { get; set; }
}