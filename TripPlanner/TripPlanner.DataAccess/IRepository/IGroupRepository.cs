using System.Linq.Expressions;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<RepositoryResponse<bool>> Update(Group post);
        Task<RepositoryResponse<bool>> AddParticipantToGroup(ParticipantGroup participant);
        Task<RepositoryResponse<bool>> UpdateParticipantGroup(ParticipantGroup participant);
        Task<RepositoryResponse<bool>> DeleteParticipantFromGroup(ParticipantGroup participant);
    }
}
