using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class QuestionnaireVote
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public QuestionnaireAnswer QuestionnaireAnswer { get; set; } = null!;
        public int QuestionnaireAnswerId { get; set; }
    }
}
