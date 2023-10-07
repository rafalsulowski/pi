using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.Services.MessageService
{
    public interface IMessageService
    {
        Task<RepositoryResponse<List<Message>>> GetMessagesAsync(Expression<Func<Message, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Message>> GetMessageAsync(Expression<Func<Message, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateMessage(Message Bill);
        Task<RepositoryResponse<bool>> UpdateMessage(Message Bill);
        Task<RepositoryResponse<bool>> DeleteMessage(Message Bill);
    }
}
