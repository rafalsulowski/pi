using TripPlanner.Models.DTO.QuestionnaireDTOs;

namespace TripPlanner.Models
{
    public class QuestionnaireVote
    {
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public QuestionnaireAnswer QuestionnaireAnswer { get; set; } = null!;
        public int QuestionnaireAnswerId { get; set; }

        
        public static implicit operator QuestionnaireVoteDTO(QuestionnaireVote data)
        {
            if (data == null)
                return null;

            return new QuestionnaireVoteDTO
            {
                UserId = data.UserId,
                QuestionnaireAnswerId = data.QuestionnaireAnswerId
            };
        }
    }
}
