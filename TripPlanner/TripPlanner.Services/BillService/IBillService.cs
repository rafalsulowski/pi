using System.Linq.Expressions;
using TripPlanner.Models;

namespace TripPlanner.Services.BillService
{
    public interface IBillService
    {
        Task<RepositoryResponse<List<Bill>>> GetBillsAsync(Expression<Func<Bill, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Bill>> GetBillAsync(Expression<Func<Bill, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<List<ParticipantBill>>> GetParticipantsBillAsync(Expression<Func<ParticipantBill, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<ParticipantBill>> GetParticipantBillAsync(Expression<Func<ParticipantBill, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<List<BillPicture>>> GetBillPicturesAsync(Expression<Func<BillPicture, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<BillPicture>> GetBillPictureAsync(Expression<Func<BillPicture, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateBill(Bill Bill);
        Task<RepositoryResponse<bool>> UpdateBill(Bill Bill);
        Task<RepositoryResponse<bool>> DeleteBill(Bill Bill);
        Task<RepositoryResponse<bool>> AddParticipantToBill(ParticipantBill participant);
        Task<RepositoryResponse<bool>> UpdateParticipantBill(ParticipantBill participant);
        Task<RepositoryResponse<bool>> DeleteParticipantFromBill(ParticipantBill participant);
        Task<RepositoryResponse<bool>> AddPictureToBill(BillPicture picture);
        Task<RepositoryResponse<bool>> DeletePictureFromBill(BillPicture picture);
    }
}
