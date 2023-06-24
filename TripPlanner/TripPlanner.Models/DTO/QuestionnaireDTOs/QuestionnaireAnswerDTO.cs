namespace TripPlanner.Models.DTO.QuestionnaireDTOs
{
    public class QuestionnaireAnswerDTO
    {
        public int Id { get; set; }

        public int QuestionnaireId { get; set; }
        public ICollection<QuestionnaireVoteDTO> Votes { get; set; } = new List<QuestionnaireVoteDTO>();

        public string Answer { get; set; } = string.Empty;


        public static implicit operator QuestionnaireAnswer(QuestionnaireAnswerDTO data)
        {
            if (data == null)
                return null;

            return new QuestionnaireAnswer
            {
                Id = data.Id,
                QuestionnaireId = data.QuestionnaireId,
                Votes = data.Votes.Select(u => (QuestionnaireVote)u).ToList(),
                Answer = data.Answer
            };
        }
    }
}
