using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
