using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;

namespace TripPlanner.Services.BillService
{
    public interface IBillService
    {
        Task<RepositoryResponse<bool>> CreateTransfer(Transfer Bill);
        Task<RepositoryResponse<bool>> CreateBill(Bill Bill);
        Task<RepositoryResponse<bool>> DeleteTransfer(Transfer Bill);
        Task<RepositoryResponse<bool>> DeleteBill(Bill Bill);
        Task<RepositoryResponse<bool>> DeleteBillContributors(BillContributor Bill);
    }
}
