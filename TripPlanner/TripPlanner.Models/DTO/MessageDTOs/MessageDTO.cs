using CommunityToolkit.Mvvm.ComponentModel;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.Models.MessageModels;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;

namespace TripPlanner.Models.DTO.MessageDTOs
{
    public abstract class MessageDTO : ObservableObject
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int TourId { get; set; }

        public string content;
        public string Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }
        //public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }


        public abstract Message MapFromDTO();
    }
}
