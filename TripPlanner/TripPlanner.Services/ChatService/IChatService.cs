using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.ChatService
{
    public interface IChatService
    {
        Task<RepositoryResponse<List<Chat>>> GetChatsAsync(Expression<Func<Chat, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Chat>> GetChatAsync(Expression<Func<Chat, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateChat(Chat Bill);
        Task<RepositoryResponse<bool>> UpdateChat(Chat Bill);
        Task<RepositoryResponse<bool>> DeleteChat(Chat Bill);
    }
}
