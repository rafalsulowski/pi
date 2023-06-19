using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public ICollection<QuestionnaireDTO> Questionnaires { get; set; } = new List<QuestionnaireDTO>();
        public ICollection<MessageDTO> Messages { get; set; } = new List<MessageDTO>();
    }
}
