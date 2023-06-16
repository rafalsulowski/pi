using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class Chat
    {
        public int Id { get; set; }

        public Group Group { get; set; } = null!;
        public int GroupId { get; set; }
        public ICollection<Questionnaire> Questionnaires { get; } = new List<Questionnaire>();
        public ICollection<Message> Messages { get; } = new List<Message>();
    }
}
