using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.CheckListService
{
    public interface ICheckListService
    {
        Task<RepositoryResponse<List<CheckList>>> GetCheckListsAsync(Expression<Func<CheckList, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<CheckList>> GetCheckListAsync(Expression<Func<CheckList, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateCheckList(CheckList Bill);
        Task<RepositoryResponse<bool>> UpdateCheckList(CheckList Bill);
        Task<RepositoryResponse<bool>> DeleteCheckList(CheckList Bill);
    }
}
