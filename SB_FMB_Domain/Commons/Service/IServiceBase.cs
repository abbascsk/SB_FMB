using System.Linq.Expressions;

namespace SB_FMB_Domain.Commons.Service
{
    public interface IServiceBase<TEntity>
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
		Task<int> AddRangeAsync(List<TEntity> entity);
		Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
