using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
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
        public ICollection<QuestionnaireAnswer> Answers { get; } = new List<QuestionnaireAnswer>();

        public string Question { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public QuestionnaireDTO MapToDTO()
        {
            return new QuestionnaireDTO
            {
                Id = Id,
                UserId = UserId,
                TourId = TourId,
                ChatId = ChatId,
                Answers = Answers.Select(u => u.MapToDTO()).ToList(),
                Question = Question,
                Date = Date
            };
        }
    }
}
