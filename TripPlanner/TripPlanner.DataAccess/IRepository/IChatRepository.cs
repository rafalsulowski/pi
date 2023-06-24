using System.Linq.Expressions;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task<RepositoryResponse<bool>> Update(Chat post);
        Task<RepositoryResponse<bool>> AddMessageToChat(Message Message);
        Task<RepositoryResponse<bool>> DeleteMessageFromChat(Message Message);
    }
}
