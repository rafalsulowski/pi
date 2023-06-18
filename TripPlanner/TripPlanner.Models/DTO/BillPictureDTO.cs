using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class BillPictureDTO
    {
        public int Id { get; set; }
        public int BillID { get; set; }
        public byte[] Bytes { get; set; } = new byte[0];
    }
}
