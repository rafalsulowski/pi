using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class ContributeBudgetRepository : Repository<ContributeBudget>, IContributeBudgetRepository
    {
        private ApplicationDbContext _context;
        public ContributeBudgetRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(ContributeBudget post)
        {
            var postDB = await GetFirstOrDefault(u => u.BudgetId == post.BudgetId && u.UserId == post.UserId);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "ContributeBudget with this Id was not found."
                };
            }
            _context.ContributeBudgets.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
