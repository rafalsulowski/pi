using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IQuestionnaireRepository : IRepository<Questionnaire>
    {
        Task<RepositoryResponse<bool>> Update(Questionnaire post);
    }
}
