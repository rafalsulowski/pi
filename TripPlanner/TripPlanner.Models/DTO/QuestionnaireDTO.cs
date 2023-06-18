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

        public int UserID { get; set; }
        public int TourID { get; set; }
        public int ChatID { get; set; }
        public ICollection<QuestionnaireAnswerDTO> Answers { get; } = new List<QuestionnaireAnswerDTO>();

        public string Question { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
