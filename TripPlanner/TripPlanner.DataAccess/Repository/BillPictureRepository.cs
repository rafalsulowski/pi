using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.Repository
{
    public class BillPictureRepository : Repository<BillPicture>, IBillPictureRepository
    {
        private ApplicationDbContext _context;
        public BillPictureRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepositoryResponse<bool>> Update(BillPicture post)
        {
            var postDB = await GetFirstOrDefault(u => u.Id == post.Id);
            if (postDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "BillPicture with this Id was not found."
                };
            }
            _context.BillPictures.Attach(post);
            _context.Entry(post).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
