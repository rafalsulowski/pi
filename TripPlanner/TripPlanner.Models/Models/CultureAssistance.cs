using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class CultureAssistance
    {
        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public Culture Culture { get; set; } = null!;
        public int CultureId { get; set; }

        public bool IsPrincipal { get; set; }

        public CultureAssistanceDTO MapToDTO()
        {
            return new CultureAssistanceDTO
            {
                TourId = TourId,
                CultureID = CultureId,
                IsPrincipal = IsPrincipal
            };
        }
    }
}
