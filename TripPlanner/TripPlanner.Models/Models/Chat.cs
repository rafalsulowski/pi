using TripPlanner.Models.DTO;

namespace TripPlanner.Models
{
    public class Chat
    {
        public int Id { get; set; }

        public Group Group { get; set; } = null!;
        public int GroupId { get; set; }
        public ICollection<Questionnaire> Questionnaires { get; set; } = new List<Questionnaire>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();


        public static implicit operator ChatDTO(Chat data)
        {
            if (data == null)
                return null;

            return new ChatDTO
            {
                Id = data.Id,
                GroupId = data.GroupId,
                Questionnaires = data.Questionnaires.Select(u => (QuestionnaireDTO)u).ToList(),
                Messages = data.Messages.Select(u => (MessageDTO)u).ToList(),
            };
        }
    }
}
