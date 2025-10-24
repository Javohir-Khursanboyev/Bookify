using Bookify.Application.Abstractions.Clock;

namespace Bookify.Insfrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
