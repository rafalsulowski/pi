using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.DataAccess.Repository
{
    public class ChatRepository : Repository<Chat>, IChatRepository
    {
        private ApplicationDbContext _context;
        public ChatRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Chat post)
        {
            var postDB = await GetFirstOrDefault(u => u.Id == post.Id);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Chat with this Id was not found."
                };
            }
            _context.Chats.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddMessageToChat(Message Message)
        {
            var MessageDB = _context.Messages.FirstOrDefault(u => u.UserId == Message.UserId && u.ChatId == Message.ChatId && u.Content == Message.Content && u.Date == Message.Date);
            if (MessageDB == null)
            {
                _context.Messages.Add(Message);
            }
            else
            {
                _context.Messages.Attach(Message);
                _context.Entry(Message).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteMessageFromChat(Message Message)
        {
            var res = _context.Messages.FirstOrDefault(u => u.Id == Message.Id && u.ChatId == Message.ChatId && u.Content == Message.Content && u.UserId == Message.UserId);
            if (res != null)
            {
                _context.Messages.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
