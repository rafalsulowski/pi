
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;

namespace TripPlanner.Controls.QuestionnaireControls
{
    public class AnswerGDTO : QuestionnaireAnswerDTO
    {
        public double PercentageShare { get; set; }
        public string AccurateIcon { get; set; } = string.Empty;
    }
}
