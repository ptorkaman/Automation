using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class, new()
    {
        protected readonly ApplicationDbContext _appDbContext;

        protected Repository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<TEntity> Queryable()
        {
            try
            {
                return _appDbContext.Set<TEntity>().AsNoTracking();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities", ex);
            }
        }

        public IQueryable<TEntity> Queryable(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            IQueryable<TEntity> query = _appDbContext.Set<TEntity>().AsNoTracking();

            query = include(query);

            return query;
        }

        public async Task<TEntity> GetWithCondition(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _appDbContext.Set<TEntity>().AsNoTracking();

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllWithCondition(
Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _appDbContext.Set<TEntity>().AsNoTracking();

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> query)
        {
            return await _appDbContext.Set<TEntity>().AnyAsync(query);
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _appDbContext.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities", ex);
            }
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            try
            {
                return await _appDbContext.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity", ex);
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            try
            {
                await _appDbContext.AddAsync(entity, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved", ex);
            }
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _appDbContext.AddRangeAsync(entities, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be saved", ex);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }
            try
            {
                if (_appDbContext.ChangeTracker.Entries<TEntity>().All(e => e.Entity != entity))
                    _appDbContext.Entry(entity).State = EntityState.Modified;

                _appDbContext.Update(entity);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated", ex);
            }
        }

        public async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                var updateRangeAsync = entities.ToList();

                foreach (var entity in updateRangeAsync.Where(entity => _appDbContext.ChangeTracker.Entries<TEntity>().All(e => e.Entity != entity)))
                {
                    _appDbContext.Entry(entity).State = EntityState.Modified;
                }

                _appDbContext.UpdateRange(updateRangeAsync);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return updateRangeAsync;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be updated", ex);
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }

            try
            {
                if (_appDbContext.ChangeTracker.Entries<TEntity>().All(e => e.Entity != entity))
                    _appDbContext.Entry(entity).State = EntityState.Modified;

                //if (entity is IDeletableEntity baseEntity)
                //{
                //    baseEntity.IsDeleted = true;
                //    _appDbContext.Update(entity);
                //}
                //else
                //{
                _appDbContext.Remove(entity);
                //}

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be delete", ex);
            }
        }

        public async Task<TEntity> DeleteByIdAsync(object id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }

            try
            {
                if (_appDbContext.ChangeTracker.Entries<TEntity>().All(e => e.Entity != entity))
                    _appDbContext.Entry(entity).State = EntityState.Modified;

                //if (entity is IDeletableEntity baseEntity)
                //{
                //    baseEntity.IsDeleted = true;
                //    _appDbContext.Update(entity);
                //}
                //else
                //{
                _appDbContext.Remove(entity);
                //}

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be delete", ex);
            }
        }

        public async Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }

            try
            {
                var deleteRangeAsync = entities.ToList();

                foreach (var entity in deleteRangeAsync.Where(entity => _appDbContext.ChangeTracker.Entries<TEntity>().All(e => e.Entity != entity)))
                {
                    _appDbContext.Entry(entity).State = EntityState.Modified;
                }

                //if (entities is IDeletableEntity baseEntity)
                //{
                //    baseEntity.IsDeleted = true;
                //    _appDbContext.UpdateRange(entities);
                //}
                //else
                //{
                _appDbContext.RemoveRange(entities);
                // }

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be delete: {ex.Message}");
            }
        }

        public async void Dispose() => await _appDbContext.DisposeAsync();

    }
}