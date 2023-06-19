using System.Linq.Expressions;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.BudgetExpenditureService
{
    public interface IBudgetExpenditureService
    {
        Task<RepositoryResponse<List<BudgetExpenditure>>> GetBudgetExpendituresAsync(Expression<Func<BudgetExpenditure, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<BudgetExpenditure>> GetBudgetExpenditureAsync(Expression<Func<BudgetExpenditure, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateBudgetExpenditure(BudgetExpenditure Bill);
        Task<RepositoryResponse<bool>> UpdateBudgetExpenditure(BudgetExpenditure Bill);
        Task<RepositoryResponse<bool>> DeleteBudgetExpenditure(BudgetExpenditure Bill);
    }
}
