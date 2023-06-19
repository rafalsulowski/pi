using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface ICultureRepository : IRepository<Culture>
    {
        Task<RepositoryResponse<bool>> Update(Culture post);
    }
}
