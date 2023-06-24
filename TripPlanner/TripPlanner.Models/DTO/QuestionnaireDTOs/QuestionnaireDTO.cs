namespace TripPlanner.Models.DTO.QuestionnaireDTOs
{
    public class QuestionnaireDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int TourId { get; set; }
        public int? ChatId { get; set; }
        public ICollection<QuestionnaireAnswerDTO> Answers { get; set; } = new List<QuestionnaireAnswerDTO>();

        public string Question { get; set; } = string.Empty;
        public DateTime Date { get; set; }


        public static implicit operator Questionnaire(QuestionnaireDTO data)
        {
            if (data == null)
                return null;

            return new Questionnaire
            {
                Id = data.Id,
                UserId = data.UserId,
                TourId = data.TourId,
                ChatId = data.ChatId,
                Answers = data.Answers.Select(u => (QuestionnaireAnswer)u).ToList(),
                Question = data.Question,
                Date = data.Date
            };
        }
    }
}
