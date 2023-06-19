using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class RouteDTO
    {
        public int Id { get; set; }

        public int TourId { get; set; }
        public int UserId { get; set; }
        public ICollection<StopoverDTO> Stopovers { get; set; } = new List<StopoverDTO>();

        public string Name { get; set; } = string.Empty;
        public string StartLocation{ get; set; } = string.Empty;
        public string ArriveLocation{ get; set; } = string.Empty;
        public DateTime StartDate{ get; set; }
        public DateTime ArriveDate{ get; set; }
    }
}
