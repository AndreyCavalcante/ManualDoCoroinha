using ManualDoCoroinha.DTOs;
using ManualDoCoroinha.DTOs.Prayers;
using ManualDoCoroinha.Models.Prayers;

namespace ManualDoCoroinha.Repositories.Prayers;

public interface IPrayerRepository : IBaseRepository<Prayer>
{
    Task<ResponseListDto<PrayerDto>> GetAllPrayers(Guid id, int page, int take);
    Task<ResponseListDto<PrayerFavoriteDto>> GetFavoritesByUserId(Guid id, int page, int take);
    Task<ResponseListDto<PrayerDto>> GetPrayesrByName(Guid id, int page, int take, string? search);
    Task<ResponseListDto<PrayerFavoriteDto>> GetFavoritesByName(Guid id, int page, int take, string? search);
}