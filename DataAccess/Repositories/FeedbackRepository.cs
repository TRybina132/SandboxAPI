using Core.Entities;
using Core.Interfaces.Repository;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(SandboxContext sandboxContext) : base(sandboxContext)
        {

        }
    }
}
