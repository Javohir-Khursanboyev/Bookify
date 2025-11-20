using Bookify.Application.Abstractions.Email;

namespace Bookify.Insfrastructure.Email;

public sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recipient, string subject, string body, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
