using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.ParticipantGroupService
{
    public class ParticipantGroupService : IParticipantGroupService
    {
        private readonly IParticipantGroupRepository _ParticipantGroupRepository;
        public ParticipantGroupService(IParticipantGroupRepository ParticipantGroupRepository)
        {
            _ParticipantGroupRepository = ParticipantGroupRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateParticipantGroup(ParticipantGroup ParticipantGroup)
        {
            _ParticipantGroupRepository.Add(ParticipantGroup);
            var response = await _ParticipantGroupRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteParticipantGroup(ParticipantGroup ParticipantGroup)
        {
            _ParticipantGroupRepository.Remove(ParticipantGroup);
            var response = await _ParticipantGroupRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<ParticipantGroup>> GetParticipantGroupAsync(Expression<Func<ParticipantGroup, bool>> filter, string? includeProperties = null)
        {
            var response = await _ParticipantGroupRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<ParticipantGroup>>> GetParticipantGroupsAsync(Expression<Func<ParticipantGroup, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _ParticipantGroupRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateParticipantGroup(ParticipantGroup ParticipantGroup)
        {
            var response = await _ParticipantGroupRepository.Update(ParticipantGroup);
            if(response.Success==false)
            {
                return response;
            }
            response = await _ParticipantGroupRepository.SaveChangesAsync();
            return response;
        }
    }
}
