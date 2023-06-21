using TripPlanner.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<RepositoryResponse<bool>> Update(Group post);
    }
}
