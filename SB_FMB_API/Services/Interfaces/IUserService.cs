using SB_FMB_Domain.Commons.Service;
using SB_FMB_Domain.Entities;

namespace SB_FMB_API.Services.Interfaces
{
	public interface IUserService : IServiceBase<User>
	{
		public Task<User> GetUserByUserName(string username);
	}
}
