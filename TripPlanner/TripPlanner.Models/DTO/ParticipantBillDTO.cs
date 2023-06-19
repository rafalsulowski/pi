using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class ParticipantBillDTO
    {
        public int BillId { get; set; }
        public int UserId { get; set; }

        public decimal Payment { get; set; }
        public decimal Debt { get; set; }
    }
}
