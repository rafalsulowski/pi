using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IBillPictureRepository : IRepository<BillPicture>
    {
        Task<RepositoryResponse<bool>> Update(BillPicture post);
    }
}
