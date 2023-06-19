using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.ContributeBudgetService
{
    public interface IContributeBudgetService
    {
        Task<RepositoryResponse<List<ContributeBudget>>> GetContributeBudgetsAsync(Expression<Func<ContributeBudget, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<ContributeBudget>> GetContributeBudgetAsync(Expression<Func<ContributeBudget, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateContributeBudget(ContributeBudget Bill);
        Task<RepositoryResponse<bool>> UpdateContributeBudget(ContributeBudget Bill);
        Task<RepositoryResponse<bool>> DeleteContributeBudget(ContributeBudget Bill);
    }
}
