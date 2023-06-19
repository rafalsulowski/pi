using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.BudgetExpenditureService
{
    public class BudgetExpenditureService : IBudgetExpenditureService
    {
        private readonly IBudgetExpenditureRepository _BudgetExpenditureRepository;
        public BudgetExpenditureService(IBudgetExpenditureRepository BudgetExpenditureRepository)
        {
            _BudgetExpenditureRepository = BudgetExpenditureRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateBudgetExpenditure(BudgetExpenditure BudgetExpenditure)
        {
            _BudgetExpenditureRepository.Add(BudgetExpenditure);
            var response = await _BudgetExpenditureRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteBudgetExpenditure(BudgetExpenditure BudgetExpenditure)
        {
            _BudgetExpenditureRepository.Remove(BudgetExpenditure);
            var response = await _BudgetExpenditureRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<BudgetExpenditure>> GetBudgetExpenditureAsync(Expression<Func<BudgetExpenditure, bool>> filter, string? includeProperties = null)
        {
            var response = await _BudgetExpenditureRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<BudgetExpenditure>>> GetBudgetExpendituresAsync(Expression<Func<BudgetExpenditure, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _BudgetExpenditureRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateBudgetExpenditure(BudgetExpenditure BudgetExpenditure)
        {
            var response = await _BudgetExpenditureRepository.Update(BudgetExpenditure);
            if(response.Success==false)
            {
                return response;
            }
            response = await _BudgetExpenditureRepository.SaveChangesAsync();
            return response;
        }
    }
}
