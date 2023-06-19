using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class QuestionnaireAnswer
    {
        public int Id { get; set; }

        public Questionnaire Questionnaire { get; set; } = null!;
        public int QuestionnaireId { get; set; }
        public ICollection<QuestionnaireVote> Votes { get; } = new List<QuestionnaireVote>();

        public string Answer { get; set; } = string.Empty;

        public QuestionnaireAnswerDTO MapToDTO()
        {
            return new QuestionnaireAnswerDTO 
            {
                Id = Id,
                QuestionnaireId = QuestionnaireId,
                Votes = Votes.Select(u => u.MapToDTO()).ToList(),
                Answer = Answer
            };
        }
    }
}
