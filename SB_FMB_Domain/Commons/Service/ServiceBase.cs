using SB_FMB_Domain.Commons.Entity;
using SB_FMB_Domain.Commons.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SB_FMB_Domain.Commons.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _baseRepository;

        public ServiceBase(IRepositoryBase<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return _baseRepository.GetAllAsync();
        }

        public Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _baseRepository.GetAsync(predicate);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _baseRepository.GetByIdAsync(id);
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            return _baseRepository.AddAsync(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            return _baseRepository.UpdateAsync(entity);
        }

        public Task DeleteAsync(TEntity entity)
        {
            return _baseRepository.DeleteAsync(entity);
        }

		public Task<int> AddRangeAsync(List<TEntity> entity)
		{
			throw new NotImplementedException();
		}
	}
}
