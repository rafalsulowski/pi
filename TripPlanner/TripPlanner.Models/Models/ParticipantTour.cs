using TripPlanner.Models.DTO.TourDTOs;

namespace TripPlanner.Models
{
    public class ParticipantTour
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }


        public static implicit operator ParticipantTourDTO(ParticipantTour data)
        {
            if (data == null)
                return null;

            return new ParticipantTourDTO
            {
                UserId = data.UserId,
                TourId = data.TourId
            };
        }
    }
}
