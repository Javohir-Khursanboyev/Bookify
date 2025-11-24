using Bookify.Domain.Users;
using Bookify.Insfrastructure;

namespace Bookify.Insfrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    {
    }
    public override void Add(User user)
    {
        foreach (var role in user.Roles)
        {
            context.Attach(role);
        }

        context.Add(user);
    }
}