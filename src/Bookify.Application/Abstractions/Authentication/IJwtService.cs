using Bookify.Domain.Abstractions;

namespace Bookify.Application.Abstractions.Authentication;

public interface IJwtService
{
    Task<Result<string>> GetAccesTokenAsync(string email, string password, CancellationToken cancellationToken = default);
}