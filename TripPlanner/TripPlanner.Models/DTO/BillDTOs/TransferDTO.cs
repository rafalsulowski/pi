using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;

namespace TripPlanner.Models.DTO.BillDTOs
{
    public class TransferDTO
    {
        public int SenderId { get; set; }

        public int RecipientId { get; set; }
    }
}
