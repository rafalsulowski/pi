using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
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

        public MessageDTO MapToDTO()
        {
            return new MessageDTO
            {
                Id = Id,
                UserId = UserId,
                ChatId = ChatId,
                Content = Content,
                Date = Date
            };
        }
    }
}
