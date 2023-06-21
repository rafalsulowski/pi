using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }
        public Chat Chat { get; set; } = null!;
        public int ChatId { get; set; }
        public ICollection<QuestionnaireAnswer> Answers { get; set; } = new List<QuestionnaireAnswer>();

        public string Question { get; set; } = string.Empty;
        public DateTime Date { get; set; }


        public static implicit operator QuestionnaireDTO(Questionnaire data)
        {
            if (data == null)
                return null;

            return new QuestionnaireDTO
            {
                Id = data.Id,
                UserId = data.UserId,
                TourId = data.TourId,
                ChatId = data.ChatId,
                Answers = data.Answers.Select(u => (QuestionnaireAnswerDTO)u).ToList(),
                Question = data.Question,
                Date = data.Date
            };
        }
    }
}
