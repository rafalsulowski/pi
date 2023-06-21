using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface ITourRepository : IRepository<Tour>
    {
        Task<RepositoryResponse<bool>> Update(Tour post);
    }
}
