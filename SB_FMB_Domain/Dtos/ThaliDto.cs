using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_FMB_Domain.Dtos
{
	public class NewThaliRequest
	{
		public DateTime ThaliDate { get; set; }

		public List<NewThaliItemRequest> ThaliItems { get; set; }
	}

	public class NewThaliItemRequest
	{
		public string ItemName { get; set; }
	}
}
