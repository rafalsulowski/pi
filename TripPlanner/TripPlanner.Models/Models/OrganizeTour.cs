using TripPlanner.Models.DTO.TourDTOs;

namespace TripPlanner.Models
{
    public class OrganizerTour
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }


        public static implicit operator OrganizerTourDTO(OrganizerTour data)
        {
            if (data == null)
                return null;

            return new OrganizerTourDTO
            {
                UserId = data.UserId,
                TourId = data.TourId
            };
        }
    }
}
