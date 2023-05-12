using SB_FMB_Domain.Commons;
using SB_FMB_Domain.Entities;

namespace SB_FMB_API.Services.Interfaces
{
	public interface IJwtManagerService
	{
		UserSessionResponse Authenticate(User user);
		UserSessionResponse AuthenticateMumin(Mumin mumin);
	}
}
