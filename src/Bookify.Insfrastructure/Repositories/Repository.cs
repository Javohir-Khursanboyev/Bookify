using Bookify.Domain.Abstractions;
using Bookify.Insfrastructure;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Insfrastructure.Repositories;

internal abstract class Repository<T>
    where T : Entity
{
    protected readonly ApplicationDbContext context;
    protected Repository(ApplicationDbContext applicationDbContext)
    {
        context = applicationDbContext;
    }

    public async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public virtual void Add(T entity)
    {
        context.Add(entity);
    }
}
