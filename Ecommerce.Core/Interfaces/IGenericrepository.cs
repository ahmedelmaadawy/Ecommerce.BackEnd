using System.Linq.Expressions;

namespace Ecommerce.Core.Interfaces
{
    public interface IGenericrepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] include);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] include);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
