using Bookify.Domain.Apartments;

namespace Bookify.Insfrastructure.Repositories;

internal sealed class ApartmentRepository(ApplicationDbContext context)
    : Repository<Apartment>(context), IApartmentRepository
{
}