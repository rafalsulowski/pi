using TripPlanner.Models.DTO;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IBillRepository : IRepository<Bill>
    {
        Task<RepositoryResponse<bool>> Update(Bill post);
        Task<RepositoryResponse<bool>> AddParticipantToBill(ParticipantBill participant);
        Task<RepositoryResponse<bool>> UpdateParticipantBill(ParticipantBill participant);
        Task<RepositoryResponse<bool>> DeleteParticipantFromBill(ParticipantBill participant);
        Task<RepositoryResponse<bool>> AddPictureToBill(BillPicture picture);
        Task<RepositoryResponse<bool>> DeletePictureFromBill(BillPicture picture);
    }
}
