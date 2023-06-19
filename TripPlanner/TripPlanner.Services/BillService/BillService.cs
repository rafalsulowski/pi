using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.BillService
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _BillRepository;
        public BillService(IBillRepository BillRepository)
        {
            _BillRepository = BillRepository;
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
    }
}
