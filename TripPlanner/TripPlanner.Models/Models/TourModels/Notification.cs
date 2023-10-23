using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Models.Models.UserModels;

namespace TripPlanner.Models.Models.TourModels
{
    public enum NotificationType
    {
        NotifyMessageAddedAlert = 0,
        QuestionnaireMessageAddedAlert,
        BillAddedAlert,
        TransferAddedAlert,
        RemindToPayAlert,
        SlettleUpAllert,
        AddedNewParticipantAlert,
        CheckListAddedAlert,
        AddedToTourAlert,
        NewFriendAlert,

        OtherImportantAlert,
        OtherRedundantAlert,
    }

    public class Notification
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; } = null!;

        public NotificationType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string IconPath { get; set; } = string.Empty;


        public static implicit operator NotificationDTO(Notification data)
        {
            if (data == null)
                return null;

            return new NotificationDTO
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
