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
        Task<RepositoryResponse<bool>> CreateBudget(Budget Bill);
        Task<RepositoryResponse<bool>> UpdateBudget(Budget Bill);
        Task<RepositoryResponse<bool>> DeleteBudget(Budget Bill);
    }
}
