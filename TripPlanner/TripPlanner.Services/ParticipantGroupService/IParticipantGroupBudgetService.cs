using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Services.ParticipantGroupService
{
    public interface IParticipantGroupService
    {
        Task<RepositoryResponse<List<ParticipantGroup>>> GetParticipantGroupsAsync(Expression<Func<ParticipantGroup, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<ParticipantGroup>> GetParticipantGroupAsync(Expression<Func<ParticipantGroup, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateParticipantGroup(ParticipantGroup Bill);
        Task<RepositoryResponse<bool>> UpdateParticipantGroup(ParticipantGroup Bill);
        Task<RepositoryResponse<bool>> DeleteParticipantGroup(ParticipantGroup Bill);
    }
}
