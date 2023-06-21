using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class ParticipantGroupRepository : Repository<ParticipantGroup>, IParticipantGroupRepository
    {
        private ApplicationDbContext _context;
        public ParticipantGroupRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(ParticipantGroup post)
        {
            var postDB = await GetFirstOrDefault(u => u.GroupId == post.GroupId && u.UserId == post.UserId);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "ParticipantGroup with this Id was not found."
                };
            }
            _context.ParticipantGroups.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
