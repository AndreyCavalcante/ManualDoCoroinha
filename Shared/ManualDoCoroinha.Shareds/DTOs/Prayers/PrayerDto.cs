using ManualDoCoroinha.Shared.Enums;

namespace ManualDoCoroinha.Shared.DTOs.Prayers;

public class PrayerDto
{
    public Guid PrayerId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string? Author { get; set; }
    public CategoryPrayer Category { get; set; }
    public int Order { get; set; }
    public bool IsFavorite { get; set; }
}
