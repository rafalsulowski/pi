using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models.BillModels
{
    public class TransferDTO : ShareDTO
    {
        public int SenderId { get; set; }
        public User Sender { get; set; } = null!;

        public int RecipientId { get; set; }
        public User Recipient { get; set; } = null!;



    }
}
