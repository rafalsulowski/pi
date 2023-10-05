
namespace TripPlanner.Models.DTO.TourDTOs
{
    public class EditTourDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TargetCountry { get; set; } = string.Empty;
        public int MaxParticipant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }

        public static implicit operator Tour(EditTourDTO Tour)
        {
            if (Tour == null)
                return null;

            return new Tour
            {
                Title = Tour.Title,
                Description = Tour.Description,
                TargetCountry = Tour.TargetCountry,
                MaxParticipant = Tour.MaxParticipant,
                StartDate = Tour.StartDate,
                EndDate = Tour.EndDate,
                CreateDate = Tour.CreateDate,
            };
        }
    }
}
