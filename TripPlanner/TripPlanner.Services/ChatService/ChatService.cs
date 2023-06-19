using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.ChatService
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _ChatRepository;
        public ChatService(IChatRepository ChatRepository)
        {
            _ChatRepository = ChatRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateChat(Chat Chat)
        {
            _ChatRepository.Add(Chat);
            var response = await _ChatRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteChat(Chat Chat)
        {
            _ChatRepository.Remove(Chat);
            var response = await _ChatRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Chat>> GetChatAsync(Expression<Func<Chat, bool>> filter, string? includeProperties = null)
        {
            var response = await _ChatRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Chat>>> GetChatsAsync(Expression<Func<Chat, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _ChatRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateChat(Chat Chat)
        {
            var response = await _ChatRepository.Update(Chat);
            if(response.Success==false)
            {
                return response;
            }
            response = await _ChatRepository.SaveChangesAsync();
            return response;
        }
    }
}
