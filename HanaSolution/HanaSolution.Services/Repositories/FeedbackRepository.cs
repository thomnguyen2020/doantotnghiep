using HanaSolution.Data.Models;
using HanaSolution.Services.Infrastructure;

namespace HanaSolution.Services.Repositories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {

    }
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
