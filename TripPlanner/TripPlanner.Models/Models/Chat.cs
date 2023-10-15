using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.DTO.MessageDTOs;
using TripPlanner.Models.Models.MessageModels;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.Models.Models
{
    public class Chat
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();


        public static implicit operator ChatDTO(Chat data)
        {
            if (data == null)
                return null;

            return new ChatDTO
            {
                Id = data.Id,
                TourId = data.TourId,
                Messages = data.Messages.Select(u => (MessageDTO)u).ToList(),
            };
        }
    }
}
