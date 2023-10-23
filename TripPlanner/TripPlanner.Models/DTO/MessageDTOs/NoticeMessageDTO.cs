using TripPlanner.Models.Models.MessageModels;

namespace TripPlanner.Models.DTO.MessageDTOs
{
    public class NoticeMessageDTO : MessageDTO
    {
        public static implicit operator NoticeMessage(NoticeMessageDTO data)
        {
            if (data == null)
                return null;

            return new NoticeMessage
            {
                Id = data.Id,
                UserId = data.UserId,
                TourId = data.TourId,
                Content = data.Content,
                Date = data.Date,
            };
        }
    }
}
