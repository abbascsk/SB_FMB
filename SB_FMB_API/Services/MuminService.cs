using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons.Service;
using SB_FMB_Domain.Entities;
using SB_FMB_Domain.Repositories.Interfaces;

namespace SB_FMB_API.Services
{
	public class MuminService : ServiceBase<Mumin>, IMuminService
	{
		protected IMuminRepository _muminRepository;

		public MuminService(IMuminRepository muminRepository) : base(muminRepository)
		{
			_muminRepository = muminRepository;
		}
	}
}
