using AutoMapper;
using OfficeOpenXml;
using SB_FMB_Domain.Entities;
using System;

namespace SB_FMB_API.Extensions.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ExcelWorksheet, IEnumerable<Mumin>>()
				.ConvertUsing<ExcelWorksheetConverter>();
		}
	}
}
