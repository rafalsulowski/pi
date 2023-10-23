using TripPlanner.Models.Models.TourModels;
using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<RepositoryResponse<bool>> Update(Notification post);
    }
}
