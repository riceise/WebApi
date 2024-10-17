using System.Linq.Expressions;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T>, IDisposable where T : BaseEntity
    {
        protected readonly ApplicationDbContext _сontextFactory;
        private bool _disposedValue;
        protected GenericRepository(ApplicationDbContext contextFactory)
        {
            _сontextFactory = contextFactory;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _сontextFactory.Set<T>().AsNoTracking().Where(w => !w.IsDeleted);
            return query;
        }

        public virtual IQueryable<T> GetAllWithDeleted()
        {
            IQueryable<T> query = _сontextFactory.Set<T>();
            return query;
        }

        public async Task<T?> GetByKeyAsync(int id)
        {
            return await _сontextFactory.Set<T>().FindAsync(id);
        }
        public virtual T? GetByKey(int id)
        {
            var query = _сontextFactory.Set<T>().Find(id);
            return query;
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _сontextFactory.Set<T>().AsNoTracking().Where(w => !w.IsDeleted).Where(predicate);
            return query;
        }
        public async Task<T?> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _сontextFactory.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public virtual T? First(Expression<Func<T, bool>> predicate)
        {
            return _сontextFactory.Set<T>().FirstOrDefault(predicate);
        }
        public virtual void Add(T entity)
        {
            entity.CreateDate = DateTime.UtcNow;
            entity.EditDate = DateTime.UtcNow;
            _сontextFactory.Set<T>().Add(entity);
        }
        public virtual void Delete(T entity)
        {
            _сontextFactory.Set<T>().Remove(entity);
        }
        public virtual async Task VirtualDelete(T entity, int userId)
        {
            entity.IsDeleted = true;
            entity.DeleteDate = DateTime.UtcNow;
            entity.DeletedUserId = userId;
            await SaveChangesAsync();
        }
        public virtual async Task VirtualDelete(int Id, int userId)
        {
            T? entity = _сontextFactory.Set<T>().FirstOrDefault(w => w.Id == Id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeleteDate = DateTime.Now;
                entity.DeletedUserId = userId;
                await SaveChangesAsync();
            }
        }
        public virtual void Edit(T entity)
        {
            var entry = _сontextFactory.Entry(entity);
            if (entry.State != EntityState.Added)
                entry.State = EntityState.Modified;
        }
        public virtual void Save()
        {
            _сontextFactory.SaveChanges();
        }
        
        public async Task SaveChangesAsync()
        {
            await _сontextFactory.SaveChangesAsync();
        }
        public IQueryable<T> FindByWithTake(Expression<Func<T, bool>> predicate, int skip, int take)
        {
            IQueryable<T> query = _сontextFactory.Set<T>().AsNoTracking().Where(w => !w.IsDeleted).Where(predicate).Skip(skip).Take(take);
            return query;
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _сontextFactory.Dispose();
                }

                _disposedValue = true;
            }
        }
        
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}