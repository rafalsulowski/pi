
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.DTO.BudgetDTOs;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Models.DTO.CultureDTOs;
using TripPlanner.Models.DTO.GroupDTOs;
using TripPlanner.Models.DTO.QuestionnaireDTOs;
using TripPlanner.Models.DTO.RouteDTOs;

namespace TripPlanner.Models.DTO.TourDTOs
{
    public class TourDTO
    {
        public int Id { get; set; }

        public ICollection<OrganizerTourDTO> Organizers { get; set; } = new List<OrganizerTourDTO>();
        public ICollection<ParticipantTourDTO> Participants { get; set; } = new List<ParticipantTourDTO>();
        public ICollection<CheckListDTO> CheckLists { get; set; } = new List<CheckListDTO>();
        public ICollection<QuestionnaireDTO> Questionnaires { get; set; } = new List<QuestionnaireDTO>();
        public ICollection<GroupDTO> Groups { get; set; } = new List<GroupDTO>();
        public ICollection<RouteDTO> Routes { get; set; } = new List<RouteDTO>();
        public ICollection<BillDTO> Bills { get; set; } = new List<BillDTO>();
        public ICollection<CultureAssistanceDTO> CultureAssistances { get; set; } = new List<CultureAssistanceDTO>();
        public BudgetDTO? Budget { get; set; }

        public string Title { get; set; } = string.Empty;
        public string TargetCountry { get; set; } = string.Empty;
        public int MaxParticipant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }


        public static implicit operator Tour(TourDTO data)
        {
            if (data == null)
                return null;

            return new Tour
            {
                Id = data.Id,
                Organizers = data.Organizers.Select(u => (OrganizerTour)u).ToList(),
                Participants = data.Participants.Select(u => (ParticipantTour)u).ToList(),
                CheckLists = data.CheckLists.Select(u => (CheckList)u).ToList(),
                Questionnaires = data.Questionnaires.Select(u => (Questionnaire)u).ToList(),
                Routes = data.Routes.Select(u => (Route)u).ToList(),
                Groups = data.Groups.Select(u => (Group)u).ToList(),
                Bills = data.Bills.Select(u => (Bill)u).ToList(),
                CultureAssistances = data.CultureAssistances.Select(u => (CultureAssistance)u).ToList(),
                Budget = data.Budget,
                Title = data.Title,
                TargetCountry = data.TargetCountry,
                MaxParticipant = data.MaxParticipant,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CreateDate = data.CreateDate,
            };
        }
    }
}
