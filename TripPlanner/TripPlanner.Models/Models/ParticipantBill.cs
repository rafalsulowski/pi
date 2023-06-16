using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class ParticipantBill
    {
        public Bill Bill { get; set; } = null!;
        public int BillID { get; set; }
        public User User { get; set; } = null!;
        public int UserID { get; set; }

        public decimal Payment { get; set; }
        public decimal Debt { get; set; }
    }
}
