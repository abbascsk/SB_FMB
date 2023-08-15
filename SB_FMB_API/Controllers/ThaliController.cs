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
	public class ThaliController : ControllerBase
	{
		private readonly IThaliService _thaliService;
		private readonly IThaliItemService _thaliItemService;
		private readonly IFeedbackService _feedbackService;

		public ThaliController(IThaliService thaliService, IThaliItemService thaliItemService, IFeedbackService feedbackService)
		{
			_thaliService = thaliService;
			_thaliItemService = thaliItemService;
			_feedbackService = feedbackService;
		}

		[HttpGet("All")]
		[ProducesResponseType(typeof(Response<List<Thali>>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var thalis = await _thaliService.GetAllAsync();
				return Ok(thalis);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[ProducesResponseType(typeof(Response<Thali>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> AddThali(NewThaliRequest newThaliRequest)
		{
			try
			{
				if (newThaliRequest.ThaliItems.Count() == 0)
					return BadRequest("Cannot create an empty Thali, please add atleast one item in Thali.");

				var thali = new Thali
				{
					ThaliDate = newThaliRequest.ThaliDate
				};

				var newThali = await _thaliService.AddAsync(thali);

				var thaliItems = new List<ThaliItem>();

				foreach(var thaliItem in newThaliRequest.ThaliItems)
				{
					thaliItems.Add(new ThaliItem
					{
						ThaliId = newThali.ThaliId,
						ItemName = thaliItem.ItemName,
					});
				}

				await _thaliItemService.AddRangeAsync(thaliItems);

				newThali = await _thaliService.GetByIdAsync(newThali.ThaliId);

				return Ok(newThali);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id}/Feedback")]
		[ProducesResponseType(typeof(Response<List<Feedback>>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetFeedback(int id)
		{
			try
			{
				var thalis = await _feedbackService.GetByThaliId(id);
				return Ok(thalis);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
