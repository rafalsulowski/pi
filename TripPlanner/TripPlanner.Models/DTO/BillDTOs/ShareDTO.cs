using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.Models;

namespace TripPlanner.Models.DTO.BillDTOs
{
    public class ShareDTO
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }

        public DateTime CreatedDate { get; set; }
        public decimal Value { get; set; }
        public string ImageFilePath { get; set; } = string.Empty;
    }
}
