using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.UserModels;

namespace TripPlanner.Services.FriendService
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _FriendRepository;
        public FriendService(IFriendRepository FriendRepository)
        {
            _FriendRepository = FriendRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateFriend(Friend Friend)
        {
            _FriendRepository.Add(Friend);
            var response = await _FriendRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteFriend(Friend Friend)
        {
            _FriendRepository.Remove(Friend);
            var response = await _FriendRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Friend>> GetFriendAsync(Expression<Func<Friend, bool>> filter, string? includeProperties = null)
        {
            var response = await _FriendRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Friend>>> GetFriendsAsync(Expression<Func<Friend, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _FriendRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateFriend(Friend Friend)
        {
            var response = await _FriendRepository.Update(Friend);
            if (response.Success == false)
            {
                return response;
            }
            response = await _FriendRepository.SaveChangesAsync();
            return response;
        }

    }
}
