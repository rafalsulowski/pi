using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.BillService
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _BillRepository;
        private readonly IBillPictureRepository _BillPictureRepository;
        private readonly IParticipantBillRepository _ParticipantBillRepository;
        public BillService(IBillRepository BillRepository, IBillPictureRepository billPictureRepository, IParticipantBillRepository participantBillRepository)
        {
            _BillRepository = BillRepository;
            _BillPictureRepository = billPictureRepository;
            _ParticipantBillRepository = participantBillRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateBill(Bill Bill)
        {
            _BillRepository.Add(Bill);
            var response = await _BillRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteBill(Bill Bill)
        {
            _BillRepository.Remove(Bill);
            var response = await _BillRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Bill>> GetBillAsync(Expression<Func<Bill, bool>> filter, string? includeProperties = null)
        {
            var response = await _BillRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Bill>>> GetBillsAsync(Expression<Func<Bill, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _BillRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<ParticipantBill>> GetParticipantBillAsync(Expression<Func<ParticipantBill, bool>> filter, string? includeProperties = null)
        {
            var response = await _ParticipantBillRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<ParticipantBill>>> GetParticipantsBillAsync(Expression<Func<ParticipantBill, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _ParticipantBillRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<BillPicture>> GetBillPictureAsync(Expression<Func<BillPicture, bool>> filter, string? includeProperties = null)
        {
            var response = await _BillPictureRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<BillPicture>>> GetBillPicturesAsync(Expression<Func<BillPicture, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _BillPictureRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateBill(Bill Bill)
        {
            var response = await _BillRepository.Update(Bill);
            if(response.Success==false)
            {
                return response;
            }
            response = await _BillRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> AddParticipantToBill(ParticipantBill participant)
        {
            await _BillRepository.AddParticipantToBill(participant);
            return await _BillRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> UpdateParticipantBill(ParticipantBill participant)
        {
            var response = await _BillRepository.UpdateParticipantBill(participant);
            if (response.Success == false)
            {
                return response;
            }
            response = await _BillRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteParticipantFromBill(ParticipantBill participant)
        {
            await _BillRepository.DeleteParticipantFromBill(participant);
            return await _BillRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> AddPictureToBill(BillPicture Picture)
        {
            await _BillRepository.AddPictureToBill(Picture);
            return await _BillRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> DeletePictureFromBill(BillPicture Picture)
        {
            await _BillRepository.DeletePictureFromBill(Picture);
            return await _BillRepository.SaveChangesAsync();
        }
    }
}
