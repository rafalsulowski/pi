using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.RouteService
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _RouteRepository;
        public RouteService(IRouteRepository RouteRepository)
        {
            _RouteRepository = RouteRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateRoute(Route Route)
        {
            _RouteRepository.Add(Route);
            var response = await _RouteRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteRoute(Route Route)
        {
            _RouteRepository.Remove(Route);
            var response = await _RouteRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Route>> GetRouteAsync(Expression<Func<Route, bool>> filter, string? includeProperties = null)
        {
            var response = await _RouteRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Route>>> GetRoutesAsync(Expression<Func<Route, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _RouteRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateRoute(Route Route)
        {
            var response = await _RouteRepository.Update(Route);
            if(response.Success==false)
            {
                return response;
            }
            response = await _RouteRepository.SaveChangesAsync();
            return response;
        }
    }
}
