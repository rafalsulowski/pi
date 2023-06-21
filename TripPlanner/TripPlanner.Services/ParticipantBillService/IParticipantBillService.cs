using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Services.ParticipantBillService
{
    public interface IParticipantBillService
    {
        Task<RepositoryResponse<List<ParticipantBill>>> GetParticipantBillsAsync(Expression<Func<ParticipantBill, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<ParticipantBill>> GetParticipantBillAsync(Expression<Func<ParticipantBill, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateParticipantBill(ParticipantBill Bill);
        Task<RepositoryResponse<bool>> UpdateParticipantBill(ParticipantBill Bill);
        Task<RepositoryResponse<bool>> DeleteParticipantBill(ParticipantBill Bill);
    }
}
