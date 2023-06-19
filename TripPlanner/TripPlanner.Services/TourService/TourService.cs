using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.TourService
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _TourRepository;
        public TourService(ITourRepository TourRepository)
        {
            _TourRepository = TourRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateTour(Tour Tour)
        {
            _TourRepository.Add(Tour);
            var response = await _TourRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteTour(Tour Tour)
        {
            _TourRepository.Remove(Tour);
            var response = await _TourRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Tour>> GetTourAsync(Expression<Func<Tour, bool>> filter, string? includeProperties = null)
        {
            var response = await _TourRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Tour>>> GetToursAsync(Expression<Func<Tour, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _TourRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateTour(Tour Tour)
        {
            var response = await _TourRepository.Update(Tour);
            if(response.Success==false)
            {
                return response;
            }
            response = await _TourRepository.SaveChangesAsync();
            return response;
        }
    }
}
