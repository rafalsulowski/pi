using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IQuestionnaireVoteRepository : IRepository<QuestionnaireVote>
    {
        Task<RepositoryResponse<bool>> Update(QuestionnaireVote post);
    }
}
