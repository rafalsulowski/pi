
namespace TripPlanner.Models.DTO
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public ICollection<QuestionnaireDTO> Questionnaires { get; set; } = new List<QuestionnaireDTO>();
        public ICollection<MessageDTO> Messages { get; set; } = new List<MessageDTO>();


        public static implicit operator Chat(ChatDTO data)
        {
            if (data == null)
                return null;

            return new Chat
            {
                Id = data.Id,
                GroupId = data.GroupId,
                Questionnaires = data.Questionnaires.Select(u => (Questionnaire)u).ToList(),
                Messages = data.Messages.Select(u => (Message)u).ToList(),
            };
        }
    }
}
