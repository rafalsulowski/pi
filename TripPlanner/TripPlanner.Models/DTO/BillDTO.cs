using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;

namespace TripPlanner.Models.DTO
{
    public class BillDTO
    {
        public int Id { get; set; }

        public int TourID { get; set; }
        public int UserID { get; set; }
        public ICollection<ParticipantBillDTO> Participants { get; set; } = new List<ParticipantBillDTO>();
        public ICollection<BillPictureDTO> Pictures { get; set; } = new List<BillPictureDTO>();

        public string Name { get; set; } = string.Empty;
        public decimal Ammount { get; set; }
    }
}
