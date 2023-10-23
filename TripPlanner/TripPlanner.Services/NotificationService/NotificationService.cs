using System.Linq.Expressions;
using TripPlanner.DataAccess.IRepository;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.TourModels;
using TripPlanner.Services.Notificationservice;

namespace TripPlanner.Services.NotificationService
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _NotificationRepository;
        public NotificationService(INotificationRepository NotificationRepository)
        {
            _NotificationRepository = NotificationRepository;
        }

        public async Task<RepositoryResponse<bool>> CreateNotification(Notification Notification)
        {
            _NotificationRepository.Add(Notification);
            var response = await _NotificationRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<bool>> DeleteNotification(Notification Notification)
        {
            _NotificationRepository.Remove(Notification);
            var response = await _NotificationRepository.SaveChangesAsync();
            return response;
        }

        public async Task<RepositoryResponse<Notification>> GetNotificationAsync(Expression<Func<Notification, bool>> filter, string? includeProperties = null)
        {
            var response = await _NotificationRepository.GetFirstOrDefault(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<List<Notification>>> GetNotificationsAsync(Expression<Func<Notification, bool>>? filter = null, string? includeProperties = null)
        {
            var response = await _NotificationRepository.GetAll(filter, includeProperties);
            return response;
        }

        public async Task<RepositoryResponse<bool>> UpdateNotification(Notification Notification)
        {
            var response = await _NotificationRepository.Update(Notification);
            if (response.Success == false)
            {
                return response;
            }
            response = await _NotificationRepository.SaveChangesAsync();
            return response;
        }

    }
}
