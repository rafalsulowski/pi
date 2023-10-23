﻿using System.Linq.Expressions;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.Services.Notificationservice
{
    public interface INotificationService
    {
        Task<RepositoryResponse<List<Notification>>> GetNotificationsAsync(Expression<Func<Notification, bool>>? filter = null, string? includeProperties = null);
        Task<RepositoryResponse<Notification>> GetNotificationAsync(Expression<Func<Notification, bool>> filter, string? includeProperties = null);
        Task<RepositoryResponse<bool>> CreateNotification(Notification Bill);
        Task<RepositoryResponse<bool>> UpdateNotification(Notification Bill);
        Task<RepositoryResponse<bool>> DeleteNotification(Notification Bill);
    }
}
