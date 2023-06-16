using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class CultureAssistance
    {
        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public Culture Culture { get; set; } = null!;
        public int CultureID { get; set; }

        public bool IsPrincipal { get; set; }
    }
}
