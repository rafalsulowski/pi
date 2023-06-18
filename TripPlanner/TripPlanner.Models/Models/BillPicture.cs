using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class BillPicture
    {
        public int Id { get; set; }

        public Bill Bill { get; set; } = null!;
        public int BillId { get; set; }

        public byte[] Bytes { get; set; } = new byte[0];
    }
}
