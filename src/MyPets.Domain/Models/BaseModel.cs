namespace MyPets.Domain.Models;

public abstract class BaseModel
{
    // Date of creation entity
    public DateTimeOffset CreatedDate { get; set; }
    
    // Date of update entity
    public DateTimeOffset UpdatedDate { get; set; }
}