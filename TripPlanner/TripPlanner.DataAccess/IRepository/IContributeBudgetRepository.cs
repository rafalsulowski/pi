using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IContributeBudgetRepository : IRepository<ContributeBudget>
    {
        Task<RepositoryResponse<bool>> Update(ContributeBudget post);
    }
}
