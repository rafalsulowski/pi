using TripPlanner.Models.DTO.ChatDTOs;

namespace TripPlanner.DataTemplates
{
    public class MessageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NormalMessage { get; set; }
        public DataTemplate QuestionnaireMessage { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item is TextMessageDTO ? NormalMessage : QuestionnaireMessage;
        }
    }
}
