using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;

namespace TripPlanner.Services.CheckListService
{
    public class CheckListService : ICheckListService
    {
        private readonly ICheckListRepository _CheckListRepository;
        public CheckListService(ICheckListRepository CheckListRepository)
        {
            _CheckListRepository = CheckListRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateCheckList(CheckList CheckList)
        {
            _CheckListRepository.Add(CheckList);
            var response = await _CheckListRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteCheckList(CheckList CheckList)
        {
            _CheckListRepository.Remove(CheckList);
            var response = await _CheckListRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<CheckList>> GetCheckListAsync(Expression<Func<CheckList, bool>> filter, string? includeProperties = null)
        {
            var response = await _CheckListRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<CheckList>>> GetCheckListsAsync(Expression<Func<CheckList, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _CheckListRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateCheckList(CheckList CheckList)
        {
            var response = await _CheckListRepository.Update(CheckList);
            if(response.Success==false)
            {
                return response;
            }
            response = await _CheckListRepository.SaveChangesAsync();
            return response;
        }
    }
}
