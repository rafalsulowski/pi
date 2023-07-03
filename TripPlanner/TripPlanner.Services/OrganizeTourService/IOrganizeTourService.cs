using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Services.OrganizerTourService
{
    public interface IOrganizerTourService
    {
        Task<RepositoryResponse<List<OrganizerTour>>> GetOrganizerToursAsync(Expression<Func<OrganizerTour, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<OrganizerTour>> GetOrganizerTourAsync(Expression<Func<OrganizerTour, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateOrganizerTour(OrganizerTour Bill);
        Task<RepositoryResponse<bool>> UpdateOrganizerTour(OrganizerTour Bill);
        Task<RepositoryResponse<bool>> DeleteOrganizerTour(OrganizerTour Bill);
    }
}
