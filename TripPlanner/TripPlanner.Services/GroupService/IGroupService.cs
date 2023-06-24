using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;

namespace TripPlanner.Services.GroupService
{
    public interface IGroupService
    {
        Task<RepositoryResponse<List<Group>>> GetGroupsAsync(Expression<Func<Group, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Group>> GetGroupAsync(Expression<Func<Group, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<List<ParticipantGroup>>> GetParticipantsGroupAsync(Expression<Func<ParticipantGroup, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<ParticipantGroup>> GetParticipantGroupAsync(Expression<Func<ParticipantGroup, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateGroup(Group Group);
        Task<RepositoryResponse<bool>> UpdateGroup(Group Group);
        Task<RepositoryResponse<bool>> DeleteGroup(Group Group);
        Task<RepositoryResponse<bool>> AddParticipantToGroup(ParticipantGroup participant);
        Task<RepositoryResponse<bool>> UpdateParticipantGroup(ParticipantGroup participant);
        Task<RepositoryResponse<bool>> DeleteParticipantFromGroup(ParticipantGroup participant);
    }
}
