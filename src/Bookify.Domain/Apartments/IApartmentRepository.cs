namespace Bookify.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment?> SelectByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Apartment apartment);
}
