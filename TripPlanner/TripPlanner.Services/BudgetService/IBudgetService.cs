using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Services.BudgetService
{
    public interface IBudgetService
    {
        Task<RepositoryResponse<List<Budget>>> GetBudgetsAsync(Expression<Func<Budget, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Budget>> GetBudgetAsync(Expression<Func<Budget, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<List<ContributeBudget>>> GetContributesBudgetAsync(Expression<Func<ContributeBudget, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<ContributeBudget>> GetContributeBudgetAsync(Expression<Func<ContributeBudget, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<List<BudgetExpenditure>>> GetBudgetExpendituresAsync(Expression<Func<BudgetExpenditure, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<BudgetExpenditure>> GetBudgetExpenditureAsync(Expression<Func<BudgetExpenditure, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateBudget(Budget Budget);
        Task<RepositoryResponse<bool>> UpdateBudget(Budget Budget);
        Task<RepositoryResponse<bool>> DeleteBudget(Budget Budget);
        Task<RepositoryResponse<bool>> AddContributeToBudget(ContributeBudget Contribute);
        Task<RepositoryResponse<bool>> UpdateContributeBudget(ContributeBudget Contribute);
        Task<RepositoryResponse<bool>> DeleteContributeFromBudget(ContributeBudget Contribute);
        Task<RepositoryResponse<bool>> AddExpenditureToBudget(BudgetExpenditure Expenditure);
        Task<RepositoryResponse<bool>> UpdateExpenditureBudget(BudgetExpenditure Expenditure);
        Task<RepositoryResponse<bool>> DeleteExpenditureFromBudget(BudgetExpenditure Expenditure);
    }
}
