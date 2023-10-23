using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.Models.MessageModels;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;

namespace TripPlanner.Models.DTO.MessageDTOs
{
    public abstract class MessageDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int TourId { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }


        public static implicit operator Message(MessageDTO data)
        {
            if (data == null)
                return null;

            if (data is TextMessageDTO)
            {
                return (TextMessage)data;
            }
            else if (data is NoticeMessageDTO)
            {
                return (NoticeMessage)data;
            }
            else if (data is QuestionnaireDTO)
            {
                return (Questionnaire)data;
            }
            else
                return null;
        }
    }
}
