using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace NBlog.Storage
{
    public class ManagerBase<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        public ManagerBase(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> FirstOrDefaultAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity?> FirstOrDefaultOrderByAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _context.Set<TEntity>().OrderBy(keySelector).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TEntity?> FirstOrDefaultOrderByAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _context.Set<TEntity>().Where(predicate).OrderBy(keySelector).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TEntity?> FirstOrDefaultOrderByDescendingAsync<TKey>(Expression<Func<TEntity, TKey>> order)
        {
            return await _context.Set<TEntity>().OrderByDescending(order).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TEntity?> FirstOrDefaultOrderByDescendingAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _context.Set<TEntity>().Where(predicate).OrderByDescending(keySelector).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ICollection<TEntity>> GetEntitiesAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetEntitiesOrderByAsync<Tkey>(Expression<Func<TEntity, Tkey>> keySelector)
        {
            return await _context.Set<TEntity>().OrderBy(keySelector).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetEntitiesOrderByDescendingAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _context.Set<TEntity>().OrderByDescending(keySelector).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetEntitiesAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetEntitiesOrderByAsync<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await Where(where).OrderBy(keySelector).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetEntitiesOrderByDescendingAsync<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await Where(where).OrderByDescending(keySelector).AsNoTracking().ToListAsync();
        }

        protected IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<int> AddEntityAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddEntitiesAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateEntityAsync(TEntity entity, Action<TEntity> updateAction)
        {
            if (_context.Entry(entity).State == EntityState.Deleted)
            {
                _context.Set<TEntity>().Attach(entity);
            }

            updateAction(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateEntitiesAsync(IEnumerable<TEntity> entities, Action<TEntity> updateAction)
        {
            foreach (var item in entities)
            {
                if (_context.Entry(item).State == EntityState.Detached)
                {
                    _context.Set<TEntity>().Attach(item);
                }
                updateAction(item);
            }
            return await _context.SaveChangesAsync();
        }

        public void UpdateProperty<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> updateProperty)
        {
            _context.Entry(entity).Property(updateProperty).IsModified = true;
        }

        public void UpdateEntity(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateByAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateFactory)
        {
            await _context.Set<TEntity>().Where(predicate).UpdateAsync(updateFactory);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task<ICollection<TEntity>> PageAsync(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await _context.Set<TEntity>().Skip(skip).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> PageAsync(int page, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            var skip = (page - 1) * pageSize;
            return await _context.Set<TEntity>().Where(predicate).Skip(skip).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> PageOrderByAsync<TKey>(int page, int pageSize, Expression<Func<TEntity, TKey>> keySelector)
        {
            var skip = (page - 1) * pageSize;
            return await _context.Set<TEntity>().OrderBy(keySelector).Skip(skip).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> PageOrderByDescendingAsync<TKey>(int page, int pageSize, Expression<Func<TEntity, TKey>> keySelector)
        {
            var skip = (page - 1) * pageSize;
            return await _context.Set<TEntity>().OrderByDescending(keySelector).Skip(skip).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> PageOrderByAsync<TKey>(int page, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            var skip = (page - 1) * pageSize;
            return await _context.Set<TEntity>().Where(predicate).OrderBy(keySelector).Skip(skip).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> PageOrderByDescendingAsync<TKey>(int page, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector)
        {
            var skip = (page - 1) * pageSize;
            return await _context.Set<TEntity>().Where(predicate).OrderByDescending(keySelector).Skip(skip).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<bool> AnyAsync()
        {
            return await _context.Set<TEntity>().AnyAsync();
        }


        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<int> DeleteAsync()
        {
            return await _context.Set<TEntity>().DeleteAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).DeleteAsync();
        }

        public async Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            return await _context.Set<TEntity>().DeleteRangeByKeyAsync(entities);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _context.Database.BeginTransactionAsync();
        }
    }
}
