using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class Bill
    {

        public int Id { get; set; }


        public Tour Tour { get; set; } = null!;
        public int TourID { get; set; }
        public User User { get; set; } = null!;
        public int UserID { get; set; }
        public ICollection<ParticipantBill> Participants { get; } = new List<ParticipantBill>();
        public ICollection<BillPicture> Pictures { get; } = new List<BillPicture>();
        
        public string Name { get; set; }
        public decimal Ammount { get; set; }
    }
}
