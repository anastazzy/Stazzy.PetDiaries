using MyPets.Domain.Models.PetProperties;

namespace MyPets.Domain.Models;

public class Event : BaseModel
{
    public int Id { get; set; }

    public TimeMode TimeMode { get; set; }

    public string Name { get; set; }
    public string? Notes { get; set; }
    // хозяин сам придумывает процедуры, упражнения и тд
    // ставит напоминания и пожпись к ним, выбирает где оно будет
    
    public List<User>? Users { get; set; }
}