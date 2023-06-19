using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class Stopover
    {
        public int Id { get; set; }

        public Route Route { get; set; } = null!;
        public int RouteId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int BreakTime { get; set; }

        public StopoverDTO MapToDTO()
        {
            return new StopoverDTO
            {
                Id = Id,
                RouteId = RouteId,
                Name = Name,
                Description = Description,
                Location = Location,
                BreakTime = BreakTime,
            };
        }
    }
}
