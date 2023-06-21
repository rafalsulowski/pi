using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Services.TourService
{
    public interface ITourService
    {
        Task<RepositoryResponse<List<Tour>>> GetToursAsync(Expression<Func<Tour, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Tour>> GetTourAsync(Expression<Func<Tour, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateTour(Tour Bill);
        Task<RepositoryResponse<bool>> UpdateTour(Tour Bill);
        Task<RepositoryResponse<bool>> DeleteTour(Tour Bill);
    }
}
