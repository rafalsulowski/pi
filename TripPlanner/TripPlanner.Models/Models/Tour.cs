using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Models.DTO.CultureDTOs;
using TripPlanner.Models.DTO.GroupDTOs;
using TripPlanner.Models.DTO.QuestionnaireDTOs;
using TripPlanner.Models.DTO.RouteDTOs;
using TripPlanner.Models.DTO.TourDTOs;

namespace TripPlanner.Models
{
    public class Tour
    {
        public int Id { get; set; }

        public ICollection<OrganizerTour> Organizers { get; set; } = new List<OrganizerTour>();
        public ICollection<ParticipantTour> Participants { get; set; } = new List<ParticipantTour>();
        public ICollection<CheckList> CheckLists { get; set; } = new List<CheckList>();
        public ICollection<Questionnaire> Questionnaires { get; set; } = new List<Questionnaire>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<Route> Routes { get; set; } = new List<Route>();
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
        public ICollection<CultureAssistance> CultureAssistances { get; set; } = new List<CultureAssistance>();
        public Budget? Budget { get; set; }
        public Chat? Chat { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TargetCountry { get; set; } = string.Empty;
        public int MaxParticipant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }


        public static implicit operator TourDTO(Tour data)
        {
            if (data == null)
                return null;

            return new TourDTO
            {
                Id = data.Id,
                Organizers = data.Organizers.Select(u => (OrganizerTourDTO)u).ToList(),
                Participants = data.Participants.Select(u => (ParticipantTourDTO)u).ToList(),
                CheckLists = data.CheckLists.Select(u => (CheckListDTO)u).ToList(),
                Questionnaires = data.Questionnaires.Select(u => (QuestionnaireDTO)u).ToList(),
                Routes = data.Routes.Select(u => (RouteDTO)u).ToList(),
                Groups = data.Groups.Select(u => (GroupDTO)u).ToList(),
                Bills = data.Bills.Select(u => (BillDTO)u).ToList(),
                CultureAssistances = data.CultureAssistances.Select(u => (CultureAssistanceDTO)u).ToList(),
                Budget = data.Budget,
                Chat = data.Chat,
                Title = data.Title,
                Description = data.Description,
                TargetCountry = data.TargetCountry,
                MaxParticipant = data.MaxParticipant,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CreateDate = data.CreateDate,                
            };
        }
    }
}
