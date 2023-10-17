using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;

namespace TripPlanner.Models.DTO.BillDTOs
{
    public class BillContributorDTO
    {
        public int UserId { get; set; }

        public decimal Value;
    }
}
