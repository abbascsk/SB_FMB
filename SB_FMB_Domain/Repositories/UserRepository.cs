using Microsoft.EntityFrameworkCore;
using SB_FMB_Domain.Commons.Repositories;
using SB_FMB_Domain.Data;
using SB_FMB_Domain.Entities;
using SB_FMB_Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SB_FMB_Domain.Repositories
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		protected readonly FMBDbContext _dbContext;

		public UserRepository(FMBDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<User?> GetByUsernameAsync(string username)
		{
			return await _dbContext.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
		}
	}
}
