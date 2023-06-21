using Microsoft.EntityFrameworkCore;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.DataAccess.Repository;
using TripPlanner.Models;

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

        public async Task<RepositoryResponse<bool>> UpdateParticipantBill(ParticipantBill participant)
        {
            var participantDB = _context.ParticipantBills.FirstOrDefault(u => u.BillId == participant.BillId && u.UserId == participant.UserId);
            if (participantDB == null)
            {
                return new RepositoryResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Nie istnieje taki członek rachunku"
                };
            }
            _context.ParticipantBills.Attach(participant);
            _context.Entry(participant).State = EntityState.Modified;
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeleteParticipantFromBill(ParticipantBill participant)
        {
            var res = _context.ParticipantBills.FirstOrDefault(u => u.UserId == participant.UserId && u.BillId == participant.BillId);
            if (res != null)
            {
                _context.ParticipantBills.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> AddPictureToBill(BillPicture Picture)
        {
            var PictureDB = _context.BillPictures.FirstOrDefault(u => u.Id == Picture.Id && u.BillId == Picture.BillId);
            if (PictureDB == null)
            {
                _context.BillPictures.Add(Picture);
            }
            else
            {
                _context.BillPictures.Attach(Picture);
                _context.Entry(Picture).State = EntityState.Modified;
            }
            return new RepositoryResponse<bool> { Data = true };
        }

        public async Task<RepositoryResponse<bool>> DeletePictureFromBill(BillPicture Picture)
        {
            var res = _context.BillPictures.FirstOrDefault(u => u.Id == Picture.Id && u.BillId == Picture.BillId);
            if (res != null)
            {
                _context.BillPictures.Remove(res);
            }
            return new RepositoryResponse<bool> { Data = true };
        }
    }
}
