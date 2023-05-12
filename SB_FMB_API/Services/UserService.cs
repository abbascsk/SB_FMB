using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons.Service;
using SB_FMB_Domain.Entities;
using SB_FMB_Domain.Repositories.Interfaces;

namespace SB_FMB_API.Services
{
	public class UserService : ServiceBase<User>, IUserService
	{
		protected IUserRepository _userRepository;

		public UserService(IUserRepository userRepository) : base(userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> GetUserByUserName(string username)
		{
			return await _userRepository.GetByUsernameAsync(username);
		}
	}
}
