using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IBudgetRepository : IRepository<Budget>
    {
        Task<RepositoryResponse<bool>> Update(Budget post);
    }
}
