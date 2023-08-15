using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons.Service;
using SB_FMB_Domain.Entities;
using SB_FMB_Domain.Repositories.Interfaces;

namespace SB_FMB_API.Services
{
	public class ThaliItemService : ServiceBase<ThaliItem>, IThaliItemService
	{
		protected IThaliItemRepository _thaliItemRepository;

		public ThaliItemService(IThaliItemRepository thaliItemRepository) : base(thaliItemRepository)
		{
			_thaliItemRepository = thaliItemRepository;
		}
	}
}
