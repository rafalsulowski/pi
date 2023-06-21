using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IStopoverRepository : IRepository<Stopover>
    {
        Task<RepositoryResponse<bool>> Update(Stopover post);
    }
}
