using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons;
using SB_FMB_Domain.Entities;
using System;
using System.Net;

namespace SB_FMB_API.Controllers
{
	[Route("api/v1/[controller]")]
	[Authorize]
	[ApiController]
	public class MuminController : ControllerBase
	{
		protected readonly IMapper _mapper;
		protected readonly IMuminService _muminService;

		public MuminController(IMapper mapper, IMuminService muminService)
		{
			_mapper = mapper;
			_muminService = muminService;
		}

		[HttpPost("ImportExcel")]
		public async Task<IActionResult> ImportExcel(IFormFile file)
		{
			try
			{
				if (file == null || file.Length == 0)
				{
					return BadRequest("No file uploaded.");
				}

				string filePath = Path.GetTempFileName();

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					file.CopyTo(stream);
				}

				using (var package = new ExcelPackage(new FileInfo(filePath)))
				{
					ExcelWorksheet worksheet = package.Workbook.Worksheets[1]; // Assuming the data is in the first worksheet

					IEnumerable<Mumin> mumineen = _mapper.Map<IEnumerable<Mumin>>(worksheet);

					await _muminService.AddRangeAsync(mumineen.ToList());
				}

				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
