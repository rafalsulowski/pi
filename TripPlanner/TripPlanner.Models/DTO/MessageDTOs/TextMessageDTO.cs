using TripPlanner.Models.Models.MessageModels;

namespace TripPlanner.Models.DTO.MessageDTOs
{
    public class TextMessageDTO : MessageDTO
    {
        public static implicit operator TextMessage(TextMessageDTO data)
        {
            if (data == null)
                return null;

            return new TextMessage
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
