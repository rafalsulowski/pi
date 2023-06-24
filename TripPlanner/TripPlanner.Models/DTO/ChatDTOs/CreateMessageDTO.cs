namespace TripPlanner.Models.DTO.ChatDTOs
{
    public class CreateMessageDTO
    {
        public int UserId { get; set; }
        public int ChatId { get; set; }

        public string Content { get; set; } = string.Empty;


        public static implicit operator Message(CreateMessageDTO data)
        {
            if (data == null)
                return null;

            return new Message
            {
                UserId = data.UserId,
                ChatId = data.ChatId,
                Content = data.Content,
            };
        }
    }
}
