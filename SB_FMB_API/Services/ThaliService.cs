using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons.Service;
using SB_FMB_Domain.Entities;
using SB_FMB_Domain.Repositories.Interfaces;

namespace SB_FMB_API.Services
{
	public class ThaliService : ServiceBase<Thali>, IThaliService
	{
		protected IThaliRepository _thaliRepository;

		public ThaliService(IThaliRepository thaliRepository) : base(thaliRepository)
		{
			_thaliRepository = thaliRepository;
		}

        public async Task<IEnumerable<Thali>> GetThaliByDate(DateTime thaliDate)
        {
			return await _thaliRepository.GetThaliByDate(thaliDate);
        }
    }
}
