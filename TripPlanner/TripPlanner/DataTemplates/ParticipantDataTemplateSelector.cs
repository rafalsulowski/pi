using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;

namespace TripPlanner.DataTemplates
{
    public class ParticipantDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OrganizerParticipant { get; set; }
        public DataTemplate NormalParticipant { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((ExtendParticipantDTO)item).IsOrganizer ? OrganizerParticipant : NormalParticipant;
        }
    }
}
