using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.OrganizerTourService
{
    public class OrganizerTourService : IOrganizerTourService
    {
        private readonly IOrganizerTourRepository _OrganizerTourRepository;
        public OrganizerTourService(IOrganizerTourRepository OrganizerTourRepository)
        {
            _OrganizerTourRepository = OrganizerTourRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateOrganizerTour(OrganizerTour OrganizerTour)
        {
            _OrganizerTourRepository.Add(OrganizerTour);
            var response = await _OrganizerTourRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteOrganizerTour(OrganizerTour OrganizerTour)
        {
            _OrganizerTourRepository.Remove(OrganizerTour);
            var response = await _OrganizerTourRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<OrganizerTour>> GetOrganizerTourAsync(Expression<Func<OrganizerTour, bool>> filter, string? includeProperties = null)
        {
            var response = await _OrganizerTourRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<OrganizerTour>>> GetOrganizerToursAsync(Expression<Func<OrganizerTour, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _OrganizerTourRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateOrganizerTour(OrganizerTour OrganizerTour)
        {
            var response = await _OrganizerTourRepository.Update(OrganizerTour);
            if(response.Success==false)
            {
                return response;
            }
            response = await _OrganizerTourRepository.SaveChangesAsync();
            return response;
        }
    }
}
