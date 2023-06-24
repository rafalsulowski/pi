using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;

namespace TripPlanner.Services.ChatService
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _ChatRepository;
        private readonly IMessageRepository _MessageRepository;
        public ChatService(IChatRepository ChatRepository, IMessageRepository messageRepository)
        {
            _ChatRepository = ChatRepository;
            _MessageRepository = messageRepository;
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

        public async Task<RepositoryResponse<Message>> GetMessageAsync(Expression<Func<Message, bool>> filter, string? includeProperties = null)
        {
            var response = await _MessageRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Message>>> GetMessagesAsync(Expression<Func<Message, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _MessageRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> AddMessageToChat(Message Message)
        {
            await _ChatRepository.AddMessageToChat(Message);
            return await _ChatRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> DeleteMessageFromChat(Message Message)
        {
            await _ChatRepository.DeleteMessageFromChat(Message);
            return await _ChatRepository.SaveChangesAsync();
        }
    }
}
