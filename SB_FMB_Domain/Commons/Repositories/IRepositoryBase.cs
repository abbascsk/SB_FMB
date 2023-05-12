using SB_FMB_Domain.Commons.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SB_FMB_Domain.Commons.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(long id);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IList<T> entities);
        Task DeleteAsync(T entity);
        IQueryable<T> GetQueryable();
        void DeleteTable();
    }
}
