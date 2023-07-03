namespace TripPlanner.Models.DTO.TourDTOs
{
    public class OrganizerTourDTO
    {
        public int UserId { get; set; }
        public int TourId { get; set; }


        public static implicit operator OrganizerTour(OrganizerTourDTO data)
        {
            if (data == null)
                return null;

            return new OrganizerTour
            {
                UserId = data.UserId,
                TourId = data.TourId
            };
        }
    }
}
