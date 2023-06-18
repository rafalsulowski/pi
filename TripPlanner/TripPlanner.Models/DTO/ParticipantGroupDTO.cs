using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class ParticipantGroupDTO
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public bool IsOrganizer { get; set; }
    }
}
