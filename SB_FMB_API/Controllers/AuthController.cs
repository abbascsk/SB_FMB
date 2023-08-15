using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons;
using System.Net;

namespace SB_FMB_API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IJwtManagerService _jwtManagerService;
		private readonly IUserService _userService;
        private readonly IMuminService _muminService;
        private readonly IPasswordHasher _pHasher;

		public AuthController(IJwtManagerService jwtManagerService, IUserService userService, IMuminService muminService, IPasswordHasher pHasher)
		{
			_jwtManagerService = jwtManagerService;
			_userService = userService;
			_muminService = muminService;
			_pHasher = pHasher;
		}

		[HttpPost("Authenticate")]
		[ProducesResponseType(typeof(Response<UserSessionResponse>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Authenticate([FromBody] UserLoginRequest loginRequest)
		{
			try
			{
				var user = await _userService.GetUserByUserName(loginRequest.Username);
				if (user == null)
					return Unauthorized("Invalid username or password");

				if (!_pHasher.Check(user.Password, loginRequest.Password).Verified)
					return Unauthorized("Invalid username or password");

				var token = _jwtManagerService.Authenticate(user);
				if (token == null)
					return Unauthorized();


				return Ok(token);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
        }

        [HttpPost("Mumin/Authenticate")]
        [ProducesResponseType(typeof(Response<UserSessionResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AuthenticateMumin([FromBody] MuminLoginRequest loginRequest)
        {
            try
            {
                var user = await _muminService.GetByIdAsync(loginRequest.ItsID);

                if (user == null)
                    return Unauthorized("This ITS number does not exist");

                if (user.SFNumber != loginRequest.SFNumber)
                    return Unauthorized("Invalid SF number");

                var token = _jwtManagerService.AuthenticateMumin(user);
                if (token == null)
                    return Unauthorized();


                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
