using TripPlanner.Models;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<RepositoryResponse<bool>> Update(Message post);
    }
}
