using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.DTO.MessageDTOs;

namespace TripPlanner.Models.Models.MessageModels
{
    public class TextMessage : Message
    {
        public static implicit operator TextMessageDTO(TextMessage data)
        {
            if (data == null)
                return null;

            return new TextMessageDTO
            {
                Id = data.Id,
                UserId = data.UserId,
                ChatId = data.ChatId,
                Content = data.Content,
                Date = data.Date,
            };
        }
    }
}
