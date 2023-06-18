using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class TourDTO
    {
        public int Id { get; set; }

        public ICollection<ParticipantTourDTO> Participants { get; } = new List<ParticipantTourDTO>();
        public ICollection<ParticipantTourDTO> Organizers { get; } = new List<ParticipantTourDTO>();
        public ICollection<CheckListDTO> CheckLists { get; } = new List<CheckListDTO>();
        public ICollection<QuestionnaireDTO> Questionnaires { get; } = new List<QuestionnaireDTO>();
        public ICollection<GroupDTO> Groups { get; } = new List<GroupDTO>();
        public ICollection<RouteDTO> Routes { get; } = new List<RouteDTO>();
        public ICollection<BillDTO> Bills { get; } = new List<BillDTO>();
        public ICollection<CultureAssistanceDTO> CultureAssistances { get; } = new List<CultureAssistanceDTO>();
        public BudgetDTO? Budget { get; set; }

        public string Title { get; set; } = string.Empty;
        public string TargetCountry { get; set; } = string.Empty;
        public int MaxParticipant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
