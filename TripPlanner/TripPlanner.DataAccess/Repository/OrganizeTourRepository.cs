using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class OrganizeTourRepository : Repository<OrganizeTour>, IOrganizeTourRepository
    {
        private ApplicationDbContext _context;
        public OrganizeTourRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(OrganizeTour post)
        {
            var postDB = await GetFirstOrDefault(u => u.TourId == post.TourId && u.UserId == post.UserId);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "OrganizeTour with this Id was not found."
                };
            }
            _context.OrganizeTours.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
