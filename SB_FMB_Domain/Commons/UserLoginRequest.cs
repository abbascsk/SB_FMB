using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_FMB_Domain.Commons
{
	public class UserLoginRequest
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}

	public class UserSessionResponse
	{
		public string token { get; set; }
		public string username { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string mobile { get; set; }
	}
    public class MuminLoginRequest
    {
        public int ItsID { get; set; }
        public int SFNumber { get; set; }
    }
}
