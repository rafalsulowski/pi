using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.QuestionnaireDTOs;

namespace TripPlanner.Controls.QuestionnaireControls
{
    public class AnswerGDTO : QuestionnaireAnswerDTO
    {
        public double PercentageShare { get; set; }
        public string AccurateIcon { get; set; } = string.Empty;
    }
}
