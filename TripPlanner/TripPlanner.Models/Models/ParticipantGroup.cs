using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class ParticipantGroup
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Group Group { get; set; } = null!;
        public int GroupId { get; set; }

        public bool IsOrganizer { get; set; }
    }
}
