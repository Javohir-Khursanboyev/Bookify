using System.Security;
using Bookify.Domain.Users;
using Microsoft.AspNetCore.Authorization;

namespace Bookify.Insfrastructure.Authorization;

internal sealed class UserRolesResponse
{
    public Guid UserId { get; init; }

    public List<Role> Roles { get; init; } = [];
}