
namespace TripPlanner.Models.DTO
{
    public class ParticipantTourDTO
    {
        public int UserId { get; set; }
        public int TourId { get; set; }


        public static implicit operator ParticipantTour(ParticipantTourDTO data)
        {
            if (data == null)
                return null;

            return new ParticipantTour
            {
                UserId = data.UserId,
                TourId = data.TourId
            };
        }
    }
}
