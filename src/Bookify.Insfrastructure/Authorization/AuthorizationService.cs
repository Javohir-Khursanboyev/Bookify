using Bookify.Domain.Users;
using Bookify.Insfrastructure;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Insfrastructure.Authorization;

internal sealed class AuthorizationService
{
    private readonly ApplicationDbContext dbContext;

    public AuthorizationService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<UserRolesResponse> GetRolesForUserAsync(string identityId)
    {
        UserRolesResponse roles = await dbContext.Set<User>()
            .Where(u => u.IdentityId == identityId)
            .Select(u => new UserRolesResponse
            {
                UserId = u.Id,
                Roles = u.Roles.ToList()
            })
            .FirstAsync();

        return roles;
    }
}
