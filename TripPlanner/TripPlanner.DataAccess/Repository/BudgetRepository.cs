using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TripPlanner.DataAccess.Repository
{
    public class BudgetRepository : Repository<Budget>, IBudgetRepository
    {
        private ApplicationDbContext _context;
        public BudgetRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RepositoryResponse<bool>> Update(Budget post)
        {
            var postDB = await GetFirstOrDefault(u => u.Id == post.Id);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"Nie istnije budzet o id = {post.Id}."
                };
            }
            _context.Budgets.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddContributeToBudget(ContributeBudget Contribute)
        {
            var ContributeDB = _context.ContributeBudgets.FirstOrDefault(u => u.BudgetId == Contribute.BudgetId && u.UserId == Contribute.UserId);
            if (ContributeDB == null)
            {
                _context.ContributeBudgets.Add(Contribute);
            }
            else
            {
                _context.ContributeBudgets.Attach(Contribute);
                _context.Entry(Contribute).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> UpdateContributeBudget(ContributeBudget Contribute)
        {
            var ContributeDB = _context.ContributeBudgets.AsNoTracking().FirstOrDefault(u => u.BudgetId == Contribute.BudgetId && u.UserId == Contribute.UserId);
            if (ContributeDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Nie istnieje taki członek budzetu"
                };
            }
            _context.ContributeBudgets.Attach(Contribute);
            _context.Entry(Contribute).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteContributeFromBudget(ContributeBudget Contribute)
        {
            var res = _context.ContributeBudgets.FirstOrDefault(u => u.UserId == Contribute.UserId && u.BudgetId == Contribute.BudgetId);
            if (res != null)
            {
                _context.ContributeBudgets.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddExpenditureToBudget(BudgetExpenditure Expenditure)
        {
            var ExpenditureDB = _context.BudgetExpenditures.AsNoTracking().FirstOrDefault(u => u.Id == Expenditure.Id && u.BudgetId == Expenditure.BudgetId);
            if (ExpenditureDB == null)
            {
                _context.BudgetExpenditures.Add(Expenditure);
            }
            else
            {
                _context.BudgetExpenditures.Attach(Expenditure);
                _context.Entry(Expenditure).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteExpenditureFromBudget(BudgetExpenditure Expenditure)
        {
            var res = _context.BudgetExpenditures.FirstOrDefault(u => u.Id == Expenditure.Id && u.BudgetId == Expenditure.BudgetId);
            if (res != null)
            {
                _context.BudgetExpenditures.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> UpdateExpenditureBudget(BudgetExpenditure Expenditure)
        {
            var ExpenditureDB = _context.BudgetExpenditures.FirstOrDefault(u => u.BudgetId == Expenditure.BudgetId && u.Id == Expenditure.Id);
            if (ExpenditureDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Nie istnieje taki element budzetu"
                };
            }

            _context.Entry(ExpenditureDB).State = EntityState.Detached;
            _context.BudgetExpenditures.Attach(Expenditure);
            _context.Entry(Expenditure).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
