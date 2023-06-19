using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class Route
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<Stopover> Stopovers { get; } = new List<Stopover>();

        public string Name { get; set; } = string.Empty;
        public string StartLocation{ get; set; } = string.Empty;
        public string ArriveLocation{ get; set; } = string.Empty;
        public DateTime StartDate{ get; set; }
        public DateTime ArriveDate{ get; set; }

        public RouteDTO MapToDTO()
        {
            return new RouteDTO
            {
                Id = Id,
                UserId = UserId,
                TourId = TourId,
                Stopovers = Stopovers.Select(u => u.MapToDTO()).ToList(),
                Name = Name,
                StartLocation = StartLocation,
                StartDate = StartDate,
                ArriveDate = ArriveDate,
                ArriveLocation = ArriveLocation
            };
        }
    }
}
