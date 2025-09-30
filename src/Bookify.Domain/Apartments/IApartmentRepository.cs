namespace Bookify.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment?> SelectByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Insert(Apartment apartment);
}
