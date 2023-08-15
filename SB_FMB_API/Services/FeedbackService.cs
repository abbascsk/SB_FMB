using SB_FMB_API.Services.Interfaces;
using SB_FMB_Domain.Commons.Service;
using SB_FMB_Domain.Entities;
using SB_FMB_Domain.Repositories.Interfaces;

namespace SB_FMB_API.Services
{
	public class FeedbackService : ServiceBase<Feedback>, IFeedbackService
	{
		protected IFeedbackRepository _feedbackRepository;

		public FeedbackService(IFeedbackRepository feedbackRepository) : base(feedbackRepository)
		{
			_feedbackRepository = feedbackRepository;
		}

		public Task<List<Feedback>> GetByThaliId(int thaliId)
		{
			return _feedbackRepository.GetByThaliId(thaliId);
		}
	}
}
