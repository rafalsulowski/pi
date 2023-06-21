using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class CultureAssistance
    {
        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public Culture Culture { get; set; } = null!;
        public int CultureId { get; set; }

        public bool IsPrincipal { get; set; }


        public static implicit operator CultureAssistanceDTO(CultureAssistance data)
        {
            if (data == null)
                return null;

            return new CultureAssistanceDTO
            {
                TourId = data.TourId,
                CultureId = data.CultureId,
                IsPrincipal = data.IsPrincipal
            };
        }
    }
}
