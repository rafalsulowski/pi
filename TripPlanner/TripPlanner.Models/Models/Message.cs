using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Chat Chat { get; set; } = null!;
        public int ChatId { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }


        public static implicit operator MessageDTO(Message data)
        {
            if (data == null)
                return null;

            return new MessageDTO
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
