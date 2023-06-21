using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _GroupRepository;
        public GroupService(IGroupRepository GroupRepository)
        {
            _GroupRepository = GroupRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateGroup(Group Group)
        {
            _GroupRepository.Add(Group);
            var response = await _GroupRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteGroup(Group Group)
        {
            _GroupRepository.Remove(Group);
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

        public async Task<RepositoryResponse<bool>> UpdateGroup(Group Group)
        {
            var response = await _GroupRepository.Update(Group);
            if(response.Success==false)
            {
                return response;
            }
            response = await _GroupRepository.SaveChangesAsync();
            return response;
        }
    }
}
