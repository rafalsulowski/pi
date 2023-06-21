
namespace TripPlanner.Models.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ChatId { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }


        public static implicit operator Message(MessageDTO data)
        {
            if (data == null)
                return null;

            return new Message
            {
                Id = data.Id,
                UserId = data.UserId,
                ChatId = data.ChatId,
                Content = data.Content,
                Date = data.Date
            };
        }
    }
}
