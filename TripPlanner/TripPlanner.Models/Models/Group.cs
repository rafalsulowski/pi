using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class Group
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public Chat? Chat { get; set; }
        public ICollection<ParticipantGroup> Participant { get; } = new List<ParticipantGroup>();

        public string Name { get; set; } = string.Empty;
        public int Volume { get; set; }

        public GroupDTO MapToDTO()
        {
            return new GroupDTO
            {
                Id = Id,
                TourId = TourId,
                Chat = Chat != null ? Chat.MapToDTO() : null,
                Participant = Participant.Select(u => u.MapToDTO()).ToList(),
                Name = Name,
                Volume = Volume
            };
        }
    }
}
