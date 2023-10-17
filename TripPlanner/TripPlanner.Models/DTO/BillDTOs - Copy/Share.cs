using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models.BillModels
{
    public class ShareDTO
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
        public decimal Value { get; set; }
        public string ImageFilePath { get; set; } = string.Empty;
    }
}
