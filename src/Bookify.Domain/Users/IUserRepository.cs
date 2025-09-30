namespace Bookify.Domain.Users;

public interface IUserRepository
{
    Task<User?> SelectByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(User user);
}
