using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.ParticipantBillService
{
    public class ParticipantBillService : IParticipantBillService
    {
        private readonly IParticipantBillRepository _ParticipantBillRepository;
        public ParticipantBillService(IParticipantBillRepository ParticipantBillRepository)
        {
            _ParticipantBillRepository = ParticipantBillRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateParticipantBill(ParticipantBill ParticipantBill)
        {
            _ParticipantBillRepository.Add(ParticipantBill);
            var response = await _ParticipantBillRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteParticipantBill(ParticipantBill ParticipantBill)
        {
            _ParticipantBillRepository.Remove(ParticipantBill);
            var response = await _ParticipantBillRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<ParticipantBill>> GetParticipantBillAsync(Expression<Func<ParticipantBill, bool>> filter, string? includeProperties = null)
        {
            var response = await _ParticipantBillRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<ParticipantBill>>> GetParticipantBillsAsync(Expression<Func<ParticipantBill, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _ParticipantBillRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateParticipantBill(ParticipantBill ParticipantBill)
        {
            var response = await _ParticipantBillRepository.Update(ParticipantBill);
            if(response.Success==false)
            {
                return response;
            }
            response = await _ParticipantBillRepository.SaveChangesAsync();
            return response;
        }
    }
}
