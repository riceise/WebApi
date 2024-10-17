using System.Linq.Expressions;
using Data.Model;

namespace WebApplication1.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllWithDeleted();
        Task<T?> GetByKeyAsync(int id);
        T? GetByKey(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<T?> FirstAsync(Expression<Func<T, bool>> predicate);
        T? First(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        Task VirtualDelete(T entity, int userId);
        Task VirtualDelete(int id, int userId);
        void Edit(T entity);
        void Save();
        Task SaveChangesAsync();
    }
}
