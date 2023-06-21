using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class OrganizeTour
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }


        public static implicit operator OrganizeTourDTO(OrganizeTour data)
        {
            if (data == null)
                return null;

            return new OrganizeTourDTO
            {
                UserId = data.UserId,
                TourId = data.TourId
            };
        }
    }
}
