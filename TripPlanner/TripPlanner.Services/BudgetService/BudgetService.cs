using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.BudgetService
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _BudgetRepository;
        private readonly IBudgetExpenditureRepository _BudgetExpenditureRepository;
        private readonly IContributeBudgetRepository _ContributeBudgetRepository;
        public BudgetService(IBudgetRepository BudgetRepository, IBudgetExpenditureRepository BudgetExpenditureRepository, IContributeBudgetRepository ContributeBudgetRepository)
        {
            _BudgetRepository = BudgetRepository;
            _BudgetExpenditureRepository = BudgetExpenditureRepository;
            _ContributeBudgetRepository = ContributeBudgetRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateBudget(Budget Budget)
        {
            _BudgetRepository.Add(Budget);
            var response = await _BudgetRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteBudget(Budget Budget)
        {
            var resp = await _BudgetRepository.GetFirstOrDefault(u => u.Id == Budget.Id, "Contributes,Expenditures");
            if (resp.Data == null)
                return new RepositoryResponse<bool> { Data = true, Message = "Budzet zostal usuniety", Success = true };

            //removing Contributes
            Budget BudgetDB = resp.Data;
            foreach (var Contribute in BudgetDB.Contributes)
                _ContributeBudgetRepository.Remove(Contribute);

            //removing Expenditures
            foreach (var Expenditure in BudgetDB.Expenditures)
                _BudgetExpenditureRepository.Remove(Expenditure);

            _BudgetRepository.Remove(BudgetDB);
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

        public async Task<RepositoryResponse<ContributeBudget>> GetContributeBudgetAsync(Expression<Func<ContributeBudget, bool>> filter, string? includeProperties = null)
        {
            var response = await _ContributeBudgetRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<ContributeBudget>>> GetContributesBudgetAsync(Expression<Func<ContributeBudget, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _ContributeBudgetRepository.GetAll(filter, includeProperties);
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

        public async Task<RepositoryResponse<bool>> UpdateBudget(Budget Budget)
        {
            var response = await _BudgetRepository.Update(Budget);
            if (response.Success == false)
            {
                return response;
            }
            response = await _BudgetRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> AddContributeToBudget(ContributeBudget Contribute)
        {
            await _BudgetRepository.AddContributeToBudget(Contribute);
            return await _BudgetRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> UpdateContributeBudget(ContributeBudget Contribute)
        {
            var response = await _BudgetRepository.UpdateContributeBudget(Contribute);
            if (response.Success == false)
            {
                return response;
            }
            response = await _BudgetRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteContributeFromBudget(ContributeBudget Contribute)
        {
            await _BudgetRepository.DeleteContributeFromBudget(Contribute);
            return await _BudgetRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> AddExpenditureToBudget(BudgetExpenditure Expenditure)
        {
            await _BudgetRepository.AddExpenditureToBudget(Expenditure);
            return await _BudgetRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> DeleteExpenditureFromBudget(BudgetExpenditure Expenditure)
        {
            await _BudgetRepository.DeleteExpenditureFromBudget(Expenditure);
            return await _BudgetRepository.SaveChangesAsync();
        }
        public async Task<RepositoryResponse<bool>> UpdateExpenditureBudget(BudgetExpenditure Expenditure)
        {
            var response = await _BudgetRepository.UpdateExpenditureBudget(Expenditure);
            if (response.Success == false)
            {
                return response;
            }
            response = await _BudgetRepository.SaveChangesAsync();
            return response;
        }
    }
}
