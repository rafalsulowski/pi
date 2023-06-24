using System.Linq.Expressions;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IBudgetRepository : IRepository<Budget>
    {
        Task<RepositoryResponse<bool>> Update(Budget Budget);
        Task<RepositoryResponse<bool>> AddContributeToBudget(ContributeBudget Contribute);
        Task<RepositoryResponse<bool>> UpdateContributeBudget(ContributeBudget Contribute);
        Task<RepositoryResponse<bool>> DeleteContributeFromBudget(ContributeBudget Contribute);
        Task<RepositoryResponse<bool>> AddExpenditureToBudget(BudgetExpenditure Expenditure);
        Task<RepositoryResponse<bool>> UpdateExpenditureBudget(BudgetExpenditure Expenditure);
        Task<RepositoryResponse<bool>> DeleteExpenditureFromBudget(BudgetExpenditure Expenditure);
    }
}
