
using TripPlanner.Models.DTO.MessageDTOs;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;
using TripPlanner.Models.Models.TourModels;
using TripPlanner.Models.Models.UserModels;

namespace TripPlanner.Models.Models.MessageModels
{
    public abstract class Message
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Tour Tour { get; set; } = null!;
        public int TourId { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }


        public static implicit operator MessageDTO(Message data)
        {
            if (data == null)
                return null;

            if (data is TextMessage)
            {
                return (TextMessageDTO)data;
            }
            else if (data is NoticeMessage)
            {
                return (NoticeMessageDTO)data;
            }
            else if (data is Questionnaire)
            {
                return (QuestionnaireDTO)data;
            }
            else
                return null;
        }
    }
}
