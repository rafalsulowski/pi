using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IParticipantBillRepository : IRepository<ParticipantBill>
    {
        Task<RepositoryResponse<bool>> Update(ParticipantBill post);
    }
}
