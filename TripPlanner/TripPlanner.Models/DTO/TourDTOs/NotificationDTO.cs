using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Models.Models.TourModels;
using TripPlanner.Models.Models.UserModels;

namespace TripPlanner.Models.DTO.TourDTOs
{
    public class NotificationDTO
    {
        public int TourId { get; set; }

        public NotificationType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string IconPath { get; set; } = string.Empty;


        public static implicit operator Notification(NotificationDTO data)
        {
            if (data == null)
                return null;

            return new Notification
            {
                TourId = data.TourId,
                CreatedDate = data.CreatedDate,
                IconPath = data.IconPath,
                Message = data.Message,
                Name = data.Name,
                Type = data.Type,
            };
        }
    }
}
