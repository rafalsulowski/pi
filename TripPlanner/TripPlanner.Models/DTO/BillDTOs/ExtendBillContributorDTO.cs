using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models.BillModels;

namespace TripPlanner.Models.DTO.BillDTOs
{
    public class ExtendBillContributorDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Due { get; set; }
    }
}
