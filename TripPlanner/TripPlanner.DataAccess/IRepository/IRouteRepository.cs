using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IRouteRepository : IRepository<Route>
    {
        Task<RepositoryResponse<bool>> Update(Route post);
    }
}
