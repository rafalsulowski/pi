using TripPlanner.Models;
using TripPlanner.Models.Models.Tour;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IParticipantTourRepository : IRepository<ParticipantTour>
    {
        Task<RepositoryResponse<bool>> Update(ParticipantTour post);
    }
}
