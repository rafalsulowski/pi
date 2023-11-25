using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;

namespace TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs
{
    public class QuestionnaireDTO : MessageDTO
    {
        public ICollection<QuestionnaireAnswerDTO> Answers { get; set; } = new List<QuestionnaireAnswerDTO>();
        
        public override Questionnaire MapFromDTO()
        {
            return new Questionnaire
            {
                Id = Id,
                UserId = UserId,
                TourId = TourId,
                Content = Content,
                Answers = Answers.Select(u => (QuestionnaireAnswer)u).ToList(),
                Date = Date,
            };
        }
    }
}
