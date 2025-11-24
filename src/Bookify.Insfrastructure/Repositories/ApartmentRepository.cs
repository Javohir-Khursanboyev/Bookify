using Bookify.Domain.Apartments;
using Bookify.Insfrastructure;

namespace Bookify.Insfrastructure.Repositories;

internal sealed class ApartmentRepository(ApplicationDbContext context)
    : Repository<Apartment>(context), IApartmentRepository
{
}