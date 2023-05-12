using AutoMapper;
using OfficeOpenXml;
using SB_FMB_Domain.Entities;
using System;

namespace SB_FMB_API.Extensions.AutoMapper
{
	public class ExcelWorksheetConverter : ITypeConverter<ExcelWorksheet, IEnumerable<Mumin>>
	{
		public IEnumerable<Mumin> Convert(ExcelWorksheet source, IEnumerable<Mumin> destination, ResolutionContext context)
		{
			var mumineen = new List<Mumin>();

			for (int row = 2; row <= source.Dimension.Rows; row++)
			{
				var mumin = new Mumin
				{
					ItsId = int.Parse(source.Cells[row, 1].Value?.ToString()),
					FullName = source.Cells[row, 2].Value?.ToString(),
					FullNameArabic = source.Cells[row, 3].Value?.ToString(),
					SFNumber = int.Parse(source.Cells[row, 4].Value?.ToString()),
				};

				mumineen.Add(mumin);
			}

			return mumineen;
		}
	}
}
