using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IParticipantGroupRepository : IRepository<ParticipantGroup>
    {
        Task<RepositoryResponse<bool>> Update(ParticipantGroup post);
    }
}
