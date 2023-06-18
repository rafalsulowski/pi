using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class CultureAssistanceDTO
    {
        public int TourId { get; set; }
        public int CultureID { get; set; }
        public bool IsPrincipal { get; set; }
    }
}
