using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models.BillModels
{
    public class BillContributorDTO
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public decimal Value;
    }
}
