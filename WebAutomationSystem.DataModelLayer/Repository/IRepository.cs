using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> Queryable();

        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        Task<TEntity> DeleteByIdAsync(object id, CancellationToken cancellationToken);

        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> query);
        IQueryable<TEntity> Queryable(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> GetWithCondition(Expression<Func<TEntity, bool>> predicate,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<IEnumerable<TEntity>> GetAllWithCondition(
        Expression<Func<TEntity, bool>> predicate,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

    }
}