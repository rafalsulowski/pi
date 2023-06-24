using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _GroupRepository;
        private readonly IParticipantGroupRepository _ParticipantGroupRepository;
        public GroupService(IGroupRepository GroupRepository, IParticipantGroupRepository participantGroupRepository)
        {
            _GroupRepository = GroupRepository;
            _ParticipantGroupRepository = participantGroupRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateGroup(Group Group)
        {
            _GroupRepository.Add(Group);
            var response = await _GroupRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteGroup(Group Group)
        {
            var resp = await _GroupRepository.GetFirstOrDefault(u => u.Id == Group.Id, "Participants");
            if (resp.Data == null)
                return new RepositoryResponse<bool> { Data = true, Message = "Rachunek zostal usuniety", Success = true };

            //removing participants
            Group GroupDB = resp.Data;
            foreach (var participant in GroupDB.Participants)
                _ParticipantGroupRepository.Remove(participant);

            _GroupRepository.Remove(GroupDB);
            var response = await _GroupRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Group>> GetGroupAsync(Expression<Func<Group, bool>> filter, string? includeProperties = null)
        {
            var response = await _GroupRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Group>>> GetGroupsAsync(Expression<Func<Group, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _GroupRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<ParticipantGroup>> GetParticipantGroupAsync(Expression<Func<ParticipantGroup, bool>> filter, string? includeProperties = null)
        {
            var response = await _ParticipantGroupRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<ParticipantGroup>>> GetParticipantsGroupAsync(Expression<Func<ParticipantGroup, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _ParticipantGroupRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateGroup(Group Group)
        {
            var response = await _GroupRepository.Update(Group);
            if (response.Success == false)
            {
                return response;
            }
            response = await _GroupRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> AddParticipantToGroup(ParticipantGroup participant)
        {
            await _GroupRepository.AddParticipantToGroup(participant);
            return await _GroupRepository.SaveChangesAsync();
        }

        public async Task<RepositoryResponse<bool>> UpdateParticipantGroup(ParticipantGroup participant)
        {
            var response = await _GroupRepository.UpdateParticipantGroup(participant);
            if (response.Success == false)
            {
                return response;
            }
            response = await _GroupRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteParticipantFromGroup(ParticipantGroup participant)
        {
            await _GroupRepository.DeleteParticipantFromGroup(participant);
            return await _GroupRepository.SaveChangesAsync();
        }
    }
}
