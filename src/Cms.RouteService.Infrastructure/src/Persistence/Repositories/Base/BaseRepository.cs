using System;
using System.Threading;
using System.Threading.Tasks;
using Cms.RouteService.Domain.Entities;
using Cms.RouteService.Infrastructure.Persistence.Repositories.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cms.RouteService.Infrastructure.Persistence.Repositories.Base;

internal abstract class BaseRepository<TEntity>(DbContext dbContext) : IBaseRepository<TEntity>
    where TEntity : BaseRoute
{
    protected DbSet<TEntity> Entities { get; } = dbContext.Set<TEntity>();

    protected DbContext DbContext { get; } = dbContext;

    public virtual Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return Entities.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public virtual async Task<TEntity> InsertAsync(
        TEntity entity,
        CancellationToken cancellationToken
    )
    {
        await Entities.AddAsync(entity, cancellationToken);

        await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity =
            await GetByIdAsync(id, cancellationToken)
            ?? throw new InvalidOperationException($"Entity with id {id} not found.");

        Entities.Remove(entity);

        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
