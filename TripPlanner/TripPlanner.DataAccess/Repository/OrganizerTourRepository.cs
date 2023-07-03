using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class OrganizerTourRepository : Repository<OrganizerTour>, IOrganizerTourRepository
    {
        private ApplicationDbContext _context;
        public OrganizerTourRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(OrganizerTour post)
        {
            var postDB = await GetFirstOrDefault(u => u.TourId == post.TourId && u.UserId == post.UserId);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "OrganizerTour with this Id was not found."
                };
            }
            _context.OrganizerTours.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
