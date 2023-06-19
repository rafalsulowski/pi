using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IBillRepository : IRepository<Bill>
    {
        Task<RepositoryResponse<bool>> Update(Bill post);
        Task<RepositoryResponse<bool>> AddParticipantToBill(ParticipantBill participant);
        Task<RepositoryResponse<bool>> DeleteParticipantFromBill(ParticipantBill participant);
    }
}
