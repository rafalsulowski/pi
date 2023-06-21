using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models;

namespace TripPlanner.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateUser(User user)
        {
            _userRepository.Add(user);
            var response = await _userRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteUser(User user)
        {
            _userRepository.Remove(user);
            var response = await _userRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<User>> GetUserAsync(Expression<Func<User, bool>> filter, string? includeProperties = null)
        {
            var response = await _userRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<User>>> GetUsersAsync(Expression<Func<User, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _userRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateUser(User user)
        {
            var response = await _userRepository.Update(user);
            if(response.Success==false)
            {
                return response;
            }
            response = await _userRepository.SaveChangesAsync();
            return response;
        }
    }
}
