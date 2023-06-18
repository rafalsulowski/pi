using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class QuestionnaireAnswer
    {
        public int Id { get; set; }

        public Questionnaire Questionnaire { get; set; } = null!;
        public int QuestionnaireId { get; set; }
        public ICollection<QuestionnaireVote> Votes { get; } = new List<QuestionnaireVote>();


        public string Answer { get; set; } = string.Empty;
    }
}
