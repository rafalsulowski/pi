using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class ParticipantBillDTO
    {
        public int BillID { get; set; }
        public int UserID { get; set; }

        public decimal Payment { get; set; }
        public decimal Debt { get; set; }
    }
}
