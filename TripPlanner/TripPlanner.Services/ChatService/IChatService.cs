using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.Services.ChatService
{
    public interface IChatService
    {
        Task<RepositoryResponse<List<Chat>>> GetChatsAsync(Expression<Func<Chat, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Chat>> GetChatAsync(Expression<Func<Chat, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<List<Message>>> GetMessagesAsync(Expression<Func<Message, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Message>> GetMessageAsync(Expression<Func<Message, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateChat(Chat Chat);
        Task<RepositoryResponse<bool>> DeleteChat(Chat Chat);
        Task<RepositoryResponse<bool>> AddMessageToChat(Message Message);
        Task<RepositoryResponse<bool>> DeleteMessageFromChat(Message Message);
    }
}
