using System.Security.Claims;
using System.Security.Principal;

namespace SB_FMB_API.Extensions
{
	public static class IdentityExtensions
	{
		public static int GetUserID(this IIdentity identity)
		{
			ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
			Claim claim = claimsIdentity?.FindFirst("UserID");

			if (claim != null)
				return int.Parse(claim.Value);
			else
				return 0;
		}

		public static string GetUsername(this IIdentity identity)
		{
			ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
			Claim claim = claimsIdentity?.FindFirst("Username");

			if (claim != null)
				return claim.Value.ToString();
			else
				return "";
		}
	}
}
