using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class OrganizeTour
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }

        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }

        public OrganizeTourDTO MapToDTO()
        {
            return new OrganizeTourDTO
            {
                UserId = UserId,
                TourId = TourId
            };
        }
    }
}
