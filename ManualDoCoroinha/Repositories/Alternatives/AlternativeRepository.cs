using ManualDoCoroinha.Context;
using ManualDoCoroinha.Models.Alternatives;

namespace ManualDoCoroinha.Repositories.Alternatives;

public class AlternativeRepository : BaseRepository<Alternative>, IAlternativeRepository
{
    public AlternativeRepository(AppDbContext context) : base(context)
    {
    }
}
