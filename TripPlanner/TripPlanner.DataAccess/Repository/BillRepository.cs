using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        private ApplicationDbContext _context;
        public BillRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(Bill post)
        {
            var postDB = await GetFirstOrDefault(u => u.Id == post.Id);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Bill with this Id was not found."
                };
            }
            _context.Bills.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddParticipantToBill(ParticipantBill participant)
        {
            var participantDB = _context.ParticipantBills.FirstOrDefault(u => u.BillId == participant.BillId&& u.UserId == participant.UserId);
            if (participantDB == null)
            {
                _context.ParticipantBills.Add(participant);
            }
            else
            {
                _context.ParticipantBills.Attach(participant);
                _context.Entry(participant).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
