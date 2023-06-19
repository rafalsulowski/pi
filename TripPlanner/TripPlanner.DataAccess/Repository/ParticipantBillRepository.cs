using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class ParticipantBillRepository : Repository<ParticipantBill>, IParticipantBillRepository
    {
        private ApplicationDbContext _context;
        public ParticipantBillRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(ParticipantBill post)
        {
            var postDB = await GetFirstOrDefault(u => u.BillId == post.BillId && u.UserId == post.UserId);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "ParticipantBill with this Id was not found."
                };
            }
            _context.ParticipantBills.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
