using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<RepositoryResponse<bool>> Update(Message post);
    }
}
