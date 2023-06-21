using System.Linq.Expressions;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        Task<RepositoryResponse<List<T>>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<T>> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> SaveChangesAsync();
    }
}
