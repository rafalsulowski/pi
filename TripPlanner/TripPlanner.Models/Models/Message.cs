using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class Message
    {
        public string Id { get; set; }
        
        public User User { get; set; } = null!;
        public int UserID { get; set; }
        public Chat Chat { get; set; } = null!;
        public int ChatID { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
