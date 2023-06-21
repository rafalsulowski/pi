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
        Task<RepositoryResponse<bool>> CreateGroup(Group Bill);
        Task<RepositoryResponse<bool>> UpdateGroup(Group Bill);
        Task<RepositoryResponse<bool>> DeleteGroup(Group Bill);
    }
}
