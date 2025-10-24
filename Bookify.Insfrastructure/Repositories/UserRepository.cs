using Bookify.Domain.Users;

namespace Bookify.Insfrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    {
    }

}
