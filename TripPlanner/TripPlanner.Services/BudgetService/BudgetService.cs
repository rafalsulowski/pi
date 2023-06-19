using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.BudgetService
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _BudgetRepository;
        public BudgetService(IBudgetRepository BudgetRepository)
        {
            _BudgetRepository = BudgetRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateBudget(Budget Budget)
        {
            _BudgetRepository.Add(Budget);
            var response = await _BudgetRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteBudget(Budget Budget)
        {
            _BudgetRepository.Remove(Budget);
            var response = await _BudgetRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Budget>> GetBudgetAsync(Expression<Func<Budget, bool>> filter, string? includeProperties = null)
        {
            var response = await _BudgetRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Budget>>> GetBudgetsAsync(Expression<Func<Budget, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _BudgetRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateBudget(Budget Budget)
        {
            var response = await _BudgetRepository.Update(Budget);
            if(response.Success==false)
            {
                return response;
            }
            response = await _BudgetRepository.SaveChangesAsync();
            return response;
        }
    }
}
