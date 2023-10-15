using TripPlanner.Models;
using TripPlanner.Models.Models.CheckList;

namespace TripPlanner.DataAccess.IRepository
{
    public interface ICheckListFieldRepository : IRepository<CheckListField>
    {
        Task<RepositoryResponse<bool>> Update(CheckListField post);
    }
}
