using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class Route
    {
        public int Id { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<Stopover> Stopovers { get; set; } = new List<Stopover>();

        public string Name { get; set; } = string.Empty;
        public string StartLocation{ get; set; } = string.Empty;
        public string ArriveLocation{ get; set; } = string.Empty;
        public DateTime StartDate{ get; set; }
        public DateTime ArriveDate{ get; set; }


        public static implicit operator RouteDTO(Route data)
        {
            if (data == null)
                return null;

            return new RouteDTO
            {
                Id = data.Id,
                UserId = data.UserId,
                TourId = data.TourId,
                Stopovers = data.Stopovers.Select(u => (StopoverDTO)u).ToList(),
                Name = data.Name,
                StartLocation = data.StartLocation,
                StartDate = data.StartDate,
                ArriveDate = data.ArriveDate,
                ArriveLocation = data.ArriveLocation
            };
        }
    }
}
