using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IOrganizerTourRepository : IRepository<OrganizerTour>
    {
        Task<RepositoryResponse<bool>> Update(OrganizerTour post);
    }
}
