namespace TripPlanner.Models.DTO.QuestionnaireDTOs
{
    public class CreateQuestionnaireDTO
    {
        public int UserId { get; set; }
        public int TourId { get; set; }
        public int? ChatId { get; set; }
        public string Question { get; set; } = string.Empty;
        public ICollection<CreateQuestionnaireAnswerDTO> Answers { get; set; } = new List<CreateQuestionnaireAnswerDTO>();


        public static implicit operator Questionnaire(CreateQuestionnaireDTO data)
        {
            if (data == null)
                return null;

            return new Questionnaire
            {
                UserId = data.UserId,
                TourId = data.TourId,
                ChatId = data.ChatId,
                Question = data.Question,
                Answers = data.Answers.Select(u => (QuestionnaireAnswer)u).ToList()
            };
        }
    }
}
