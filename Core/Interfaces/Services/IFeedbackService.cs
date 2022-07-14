using Core.Entities;
using Core.Parameters;

namespace Core.Interfaces.Services
{
    public interface IFeedbackService
    {
        Task<IList<Feedback>> GetAll(FeedbackParameters parameters);
        Task<IList<Feedback>> GetAll();
        Task Add(Feedback feedback);
    }
}
