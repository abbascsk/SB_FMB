using Microsoft.IdentityModel.Tokens;
using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons;
using SB_FMB_Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SB_FMB_API.Services
{
	public class JwtManagerService : IJwtManagerService
	{
		private readonly IConfiguration _iConfiguration;
		public JwtManagerService(IConfiguration iConfiguration)
		{
			this._iConfiguration = iConfiguration;
		}

		public UserSessionResponse Authenticate(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(_iConfiguration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[] {
					new Claim("UserID", user.UserId.ToString()),
					new Claim("Username", user.Username),
				}),
				Expires = DateTime.UtcNow.AddMinutes(60),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new UserSessionResponse { token = tokenHandler.WriteToken(token), username = user.Username, name = user.FullName, email = user.Email, mobile = user.Mobile };
		}

		public UserSessionResponse AuthenticateMumin(Mumin mumin)
		{
			throw new NotImplementedException();
		}
	}
}
