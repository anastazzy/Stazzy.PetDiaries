using MyPets.Domain.Models.PetProperties;

namespace MyPets.Domain.Models;

/// <summary>
///     Describe experience of using concrete type of food for pet in tine interval
/// </summary>
public class PetFeed
{
    public int Id { get; set; }

    public Guid PetId { get; set; }
    public Pet? Pet { get; set; }

    public int FoodId { get; set; }
    public Food? Food { get; set; }

    public DateTimeOffset DateStart { get; set; }
    public DateTimeOffset DateEnd { get; set; }
    public string? Notes { get; set; }
    public TimeMode? FeedingMode { get; set; }
    public int DailyDoseInGrams { get; set; }
}