using ManualDoCoroinha.Context;
using ManualDoCoroinha.Models.Users;

namespace ManualDoCoroinha.Repositories.Users;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
