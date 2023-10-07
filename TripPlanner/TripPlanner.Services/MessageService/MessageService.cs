using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _MessageRepository;
        public MessageService(IMessageRepository MessageRepository)
        {
            _MessageRepository = MessageRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateMessage(Message Message)
        {
            _MessageRepository.Add(Message);
            var response = await _MessageRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteMessage(Message Message)
        {
            _MessageRepository.Remove(Message);
            var response = await _MessageRepository.SaveChangesAsync();
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

        public async Task<RepositoryResponse<bool>> UpdateMessage(Message Message)
        {
            var response = await _MessageRepository.Update(Message);
            if(response.Success==false)
            {
                return response;
            }
            response = await _MessageRepository.SaveChangesAsync();
            return response;
        }
    }
}
