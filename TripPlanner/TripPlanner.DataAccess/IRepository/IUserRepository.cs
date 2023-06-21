using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<RepositoryResponse<bool>> Update(User post);
    }
}
