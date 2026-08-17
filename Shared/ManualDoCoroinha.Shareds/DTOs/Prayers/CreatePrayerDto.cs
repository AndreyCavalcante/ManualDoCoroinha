using ManualDoCoroinha.Shared.Enums;

namespace ManualDoCoroinha.Shared.DTOs.Prayers;

public class CreatePrayerDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string? Author { get; set; }
    public CategoryPrayer Category { get; set; }
    public int Order { get; set; }
}
