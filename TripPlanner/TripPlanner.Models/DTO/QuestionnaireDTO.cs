using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class QuestionnaireDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int TourId { get; set; }
        public int ChatId { get; set; }
        public ICollection<QuestionnaireAnswerDTO> Answers { get; set; } = new List<QuestionnaireAnswerDTO>();

        public string Question { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
