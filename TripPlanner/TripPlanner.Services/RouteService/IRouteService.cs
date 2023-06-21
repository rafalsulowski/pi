using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Services.RouteService
{
    public interface IRouteService
    {
        Task<RepositoryResponse<List<Route>>> GetRoutesAsync(Expression<Func<Route, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Route>> GetRouteAsync(Expression<Func<Route, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateRoute(Route Bill);
        Task<RepositoryResponse<bool>> UpdateRoute(Route Bill);
        Task<RepositoryResponse<bool>> DeleteRoute(Route Bill);
    }
}
