using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons;
using SB_FMB_Domain.Dtos;
using SB_FMB_Domain.Entities;
using System.Net;

namespace SB_FMB_API.Controllers
{
	[Route("api/v1/[controller]")]
	[Authorize]
	[ApiController]
	public class AppController : ControllerBase
	{
		private readonly IThaliService _thaliService;
		private readonly IThaliItemService _thaliItemService;
		private readonly IFeedbackService _feedbackService;

		public AppController(IThaliService thaliService, IThaliItemService thaliItemService, IFeedbackService feedbackService)
		{
			_thaliService = thaliService;
			_thaliItemService = thaliItemService;
			_feedbackService = feedbackService;
		}

		[HttpGet("thaliByDate/{date}")]
		[ProducesResponseType(typeof(Response<List<Thali>>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetThaliByDate(string date)
		{
			try
			{
				var thalis = await _thaliService.GetThaliByDate(DateTime.Parse(date));
				return Ok(thalis);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
