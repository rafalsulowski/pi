using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task<RepositoryResponse<bool>> Update(Chat post);
    }
}
