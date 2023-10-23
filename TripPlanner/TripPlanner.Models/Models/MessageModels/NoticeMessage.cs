using TripPlanner.Models.DTO.MessageDTOs;

namespace TripPlanner.Models.Models.MessageModels
{
    /// <summary>
    /// Typ wiadomości wyświetlanej na czacie: ogłoszenie/ważna informacja/wyróżniona (tylko dla organizatora)
    /// </summary>
    public class NoticeMessage : Message
    {
        public static implicit operator NoticeMessageDTO(NoticeMessage data)
        {
            if (data == null)
                return null;

            return new NoticeMessageDTO
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
