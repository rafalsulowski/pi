using TripPlanner.Models;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.UserModels;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<RepositoryResponse<bool>> Update(User post);
    }
}
