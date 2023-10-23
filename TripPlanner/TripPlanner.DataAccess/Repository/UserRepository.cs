using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.UserModels;

namespace TripPlanner.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(User post)
        {
            var postDB = await GetFirstOrDefault(u => u.Id == post.Id);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "User with this Id was not found."
                };
            }
            _context.Users.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
