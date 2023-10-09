using TripPlanner.Models.DTO.ChatDTOs;

namespace TripPlanner.DataTemplates
{
    public class MessageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextOtherMessage { get; set; }
        public DataTemplate TextMyMessage { get; set; }
        public DataTemplate QuestionnaireMessage { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch(item)
            {
                case TextMessageDTO:
                    return TextOtherMessage;
            }
            return item is TextMessageDTO ? NormalMessage : QuestionnaireMessage;
        }
    }
}
