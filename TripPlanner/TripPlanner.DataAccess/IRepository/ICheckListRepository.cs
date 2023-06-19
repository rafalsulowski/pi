using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface ICheckListRepository : IRepository<CheckList>
    {
        Task<RepositoryResponse<bool>> Update(CheckList post);
    }
}
