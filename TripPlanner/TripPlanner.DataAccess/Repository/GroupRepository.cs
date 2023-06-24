using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Group post)
        {
            var postDB = await GetFirstOrDefault(u => u.Id == post.Id);
            var res = postDB.Data;
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = $"Nie istnieje grupa o id = {post.Id}"
                };
            }
            _context.Entry(res).State = EntityState.Detached;
            _context.Groups.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddParticipantToGroup(ParticipantGroup participant)
        {
            var participantDB = _context.ParticipantGroups.FirstOrDefault(u => u.GroupId == participant.GroupId && u.UserId == participant.UserId);
            if (participantDB == null)
            {
                _context.ParticipantGroups.Add(participant);
            }
            else
            {
                _context.ParticipantGroups.Attach(participant);
                _context.Entry(participant).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> UpdateParticipantGroup(ParticipantGroup participant)
        {
            var participantDB = _context.ParticipantGroups.AsNoTracking().FirstOrDefault(u => u.GroupId == participant.GroupId && u.UserId == participant.UserId);
            if (participantDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Nie istnieje taki uczestnik grupy"
                };
            }
            _context.ParticipantGroups.Attach(participant);
            _context.Entry(participant).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteParticipantFromGroup(ParticipantGroup participant)
        {
            var res = _context.ParticipantGroups.FirstOrDefault(u => u.UserId == participant.UserId && u.GroupId == participant.GroupId);
            if (res != null)
            {
                _context.ParticipantGroups.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
