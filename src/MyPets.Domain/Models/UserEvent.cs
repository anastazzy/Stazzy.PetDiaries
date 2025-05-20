namespace MyPets.Domain.Models;

public class UserEvent : BaseModel
{
    public int Id { get; set; }
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public int EventId { get; set; }
    public Event? Event { get; set; }
    
    public Guid OwnerId { get; set; }
    public bool IsPrivate { get; set; }
    
    public List<Pet>? Pets { get; set; }
}