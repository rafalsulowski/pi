using TripPlanner.Models.Models;

namespace TripPlanner.DataAccess.IRepository
{
    public interface ICheckListFieldRepository : IRepository<CheckListField>
    {
        Task<RepositoryResponse<bool>> Update(CheckListField post);
    }
}
