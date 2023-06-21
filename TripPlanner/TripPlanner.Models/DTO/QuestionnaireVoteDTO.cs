
namespace TripPlanner.Models.DTO
{
    public class QuestionnaireVoteDTO
    {
        public int UserId { get; set; }
        public int QuestionnaireAnswerId { get; set; }


        public static implicit operator QuestionnaireVote(QuestionnaireVoteDTO data)
        {
            if (data == null)
                return null;

            return new QuestionnaireVote
            {
                UserId = data.UserId,
                QuestionnaireAnswerId = data.QuestionnaireAnswerId
            };
        }
    }
}
