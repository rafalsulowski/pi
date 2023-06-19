using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IBudgetExpenditureRepository : IRepository<BudgetExpenditure>
    {
        Task<RepositoryResponse<bool>> Update(BudgetExpenditure post);
    }
}
