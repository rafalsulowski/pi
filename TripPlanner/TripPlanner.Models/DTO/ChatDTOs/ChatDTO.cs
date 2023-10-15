using TripPlanner.Models.DTO.MessageDTOs;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.MessageModels;

namespace TripPlanner.Models.DTO.ChatDTOs
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public ICollection<MessageDTO> Messages { get; set; } = new List<MessageDTO>();


        public static implicit operator Chat(ChatDTO data)
        {
            if (data == null)
                return null;

            return new Chat
            {
                Id = data.Id,
                TourId = data.TourId,
                Messages = data.Messages.Select(u => (Message)u).ToList(),
            };
        }
    }
}
