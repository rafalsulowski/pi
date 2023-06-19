using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int ChatId { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
