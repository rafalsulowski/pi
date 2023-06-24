namespace TripPlanner.Models.DTO.TourDTOs
{
    public class OrganizeTourDTO
    {
        public int UserId { get; set; }
        public int TourId { get; set; }


        public static implicit operator OrganizeTour(OrganizeTourDTO data)
        {
            if (data == null)
                return null;

            return new OrganizeTour
            {
                UserId = data.UserId,
                TourId = data.TourId
            };
        }
    }
}
