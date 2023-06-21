using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.OrganizeTourService
{
    public class OrganizeTourService : IOrganizeTourService
    {
        private readonly IOrganizeTourRepository _OrganizeTourRepository;
        public OrganizeTourService(IOrganizeTourRepository OrganizeTourRepository)
        {
            _OrganizeTourRepository = OrganizeTourRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateOrganizeTour(OrganizeTour OrganizeTour)
        {
            _OrganizeTourRepository.Add(OrganizeTour);
            var response = await _OrganizeTourRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteOrganizeTour(OrganizeTour OrganizeTour)
        {
            _OrganizeTourRepository.Remove(OrganizeTour);
            var response = await _OrganizeTourRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<OrganizeTour>> GetOrganizeTourAsync(Expression<Func<OrganizeTour, bool>> filter, string? includeProperties = null)
        {
            var response = await _OrganizeTourRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<OrganizeTour>>> GetOrganizeToursAsync(Expression<Func<OrganizeTour, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _OrganizeTourRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateOrganizeTour(OrganizeTour OrganizeTour)
        {
            var response = await _OrganizeTourRepository.Update(OrganizeTour);
            if(response.Success==false)
            {
                return response;
            }
            response = await _OrganizeTourRepository.SaveChangesAsync();
            return response;
        }
    }
}
