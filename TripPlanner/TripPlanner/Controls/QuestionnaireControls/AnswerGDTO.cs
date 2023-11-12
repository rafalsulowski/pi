
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;

namespace TripPlanner.Controls.QuestionnaireControls
{
    public class AnswerGDTO
    {
        public int Id {  get; set; }
        public int QuestionnaireId {  get; set; }
        public DateTime Date {  get; set; }
        public string Answer {  get; set; } = string.Empty;
        public double PercentageShare { get; set; }
        public string AccurateIcon { get; set; } = string.Empty;
    }
}
