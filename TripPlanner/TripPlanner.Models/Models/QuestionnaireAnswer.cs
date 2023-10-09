using TripPlanner.Models.DTO.QuestionnaireDTOs;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.Models
{
    public class QuestionnaireAnswer
    {
        public int Id { get; set; }

        public Questionnaire Questionnaire { get; set; } = null!;
        public int QuestionnaireId { get; set; }
        public ICollection<QuestionnaireVote> Votes { get; set; } = new List<QuestionnaireVote>();

        public string Answer { get; set; } = string.Empty;


        public static implicit operator QuestionnaireAnswerDTO(QuestionnaireAnswer data)
        {
            if (data == null)
                return null;

            return new QuestionnaireAnswerDTO
            {
                Id = data.Id,
                QuestionnaireId = data.QuestionnaireId,
                Votes = data.Votes.Select(u => (QuestionnaireVoteDTO)u).ToList(),
                Answer = data.Answer
            };
        }
    }
}
