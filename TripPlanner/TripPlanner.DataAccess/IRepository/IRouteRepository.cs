using System.Linq.Expressions;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IRouteRepository : IRepository<Route>
    {
        Task<RepositoryResponse<bool>> Update(Route post);
        Task<RepositoryResponse<bool>> AddStopoverToRoute(Stopover Stopover);
        Task<RepositoryResponse<bool>> UpdateStopover(Stopover Stopover);
        Task<RepositoryResponse<bool>> DeleteStopoverFromRoute(Stopover Stopover);
    }
}
