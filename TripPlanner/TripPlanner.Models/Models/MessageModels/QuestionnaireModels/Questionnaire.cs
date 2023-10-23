using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.Models.TourModels;

namespace TripPlanner.Models.Models.MessageModels.QuestionnaireModels
{
    public class Questionnaire : Message
    {
        public ICollection<QuestionnaireAnswer> Answers { get; set; } = new List<QuestionnaireAnswer>();


        public static implicit operator QuestionnaireDTO(Questionnaire data)
        {
            if (data == null)
                return null;

            return new QuestionnaireDTO
            {
                Id = data.Id,
                UserId = data.UserId,
                TourId = data.TourId,
                Answers = data.Answers.Select(u => (QuestionnaireAnswerDTO)u).ToList(),
                Content = data.Content,
                Date = data.Date
            };
        }
    }
}
