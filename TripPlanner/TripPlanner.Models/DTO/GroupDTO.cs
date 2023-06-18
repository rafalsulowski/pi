using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public ChatDTO? Chat { get; set; }
        public ICollection<ParticipantGroupDTO> Participant { get; } = new List<ParticipantGroupDTO>();

        public string Name { get; set; } = string.Empty;
        public int Volume { get; set; }

    }
}
