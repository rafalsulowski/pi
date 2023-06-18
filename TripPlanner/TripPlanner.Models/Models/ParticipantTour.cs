using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class ParticipantTour
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
    }
}
