using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IParticipantTourRepository : IRepository<ParticipantTour>
    {
        Task<RepositoryResponse<bool>> Update(ParticipantTour post);
    }
}
