
namespace TripPlanner.Models.DTO.TourDTOs
{
    public class CreateTourDTO
    {
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TargetCountry { get; set; } = string.Empty;
        public int MaxParticipant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static implicit operator Tour(CreateTourDTO Tour)
        {
            if (Tour == null)
                return null;

            return new Tour
            {
                Title = Tour.Title,
                TargetCountry = Tour.TargetCountry,
                MaxParticipant = Tour.MaxParticipant,
                StartDate = Tour.StartDate,
                EndDate = Tour.EndDate,
            };
        }
    }
}
