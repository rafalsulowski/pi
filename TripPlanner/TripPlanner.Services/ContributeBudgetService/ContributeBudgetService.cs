using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.ContributeBudgetService
{
    public class ContributeBudgetService : IContributeBudgetService
    {
        private readonly IContributeBudgetRepository _ContributeBudgetRepository;
        public ContributeBudgetService(IContributeBudgetRepository ContributeBudgetRepository)
        {
            _ContributeBudgetRepository = ContributeBudgetRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateContributeBudget(ContributeBudget ContributeBudget)
        {
            _ContributeBudgetRepository.Add(ContributeBudget);
            var response = await _ContributeBudgetRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteContributeBudget(ContributeBudget ContributeBudget)
        {
            _ContributeBudgetRepository.Remove(ContributeBudget);
            var response = await _ContributeBudgetRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<ContributeBudget>> GetContributeBudgetAsync(Expression<Func<ContributeBudget, bool>> filter, string? includeProperties = null)
        {
            var response = await _ContributeBudgetRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<ContributeBudget>>> GetContributeBudgetsAsync(Expression<Func<ContributeBudget, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _ContributeBudgetRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateContributeBudget(ContributeBudget ContributeBudget)
        {
            var response = await _ContributeBudgetRepository.Update(ContributeBudget);
            if(response.Success==false)
            {
                return response;
            }
            response = await _ContributeBudgetRepository.SaveChangesAsync();
            return response;
        }
    }
}
