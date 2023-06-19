using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class QuestionnaireAnswerDTO
    {
        public int Id { get; set; }

        public int QuestionnaireId { get; set; }
        public ICollection<QuestionnaireVoteDTO> Votes { get; set; } = new List<QuestionnaireVoteDTO>();


        public string Answer { get; set; } = string.Empty;
    }
}
