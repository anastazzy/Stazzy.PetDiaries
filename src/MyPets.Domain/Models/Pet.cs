namespace MyPets.Domain.Models;

public class Pet : BaseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}