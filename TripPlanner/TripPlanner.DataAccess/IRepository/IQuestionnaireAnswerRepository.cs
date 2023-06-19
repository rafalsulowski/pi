using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IQuestionnaireAnswerRepository : IRepository<QuestionnaireAnswer>
    {
        Task<RepositoryResponse<bool>> Update(QuestionnaireAnswer post);
    }
}
