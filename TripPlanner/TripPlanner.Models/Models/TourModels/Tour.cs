using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Models.DTO.CultureDTOs;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.DTO.RouteDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.Models.Models.CheckListModels;
using TripPlanner.Models.Models.CultureModels;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;
using TripPlanner.Models.Models.RouteModels;

namespace TripPlanner.Models.Models.TourModels
{
    public class Tour
    {
        public int Id { get; set; }

        public ICollection<ParticipantTour> Participants { get; set; } = new List<ParticipantTour>();
        public ICollection<CheckList> CheckLists { get; set; } = new List<CheckList>();
        public ICollection<Questionnaire> Questionnaires { get; set; } = new List<Questionnaire>();
        public ICollection<Route> Routes { get; set; } = new List<Route>();
        public ICollection<CultureAssistance> Cultures { get; set; } = new List<CultureAssistance>();
        public ICollection<Share> Shares { get; set; } = new List<Share>();
        public Chat Chat { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TargetCountry { get; set; } = string.Empty;
        public int MaxParticipant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string InviteLink { get; set; } = string.Empty;


        public static implicit operator TourDTO(Tour data)
        {
            if (data == null)
                return null;

            return new TourDTO
            {
                Id = data.Id,
                Participants = data.Participants.Select(u => (ParticipantTourDTO)u).ToList(),
                CheckLists = data.CheckLists.Select(u => (CheckListDTO)u).ToList(),
                Questionnaires = data.Questionnaires.Select(u => (QuestionnaireDTO)u).ToList(),
                Routes = data.Routes.Select(u => (RouteDTO)u).ToList(),
                Cultures = data.Cultures.Select(u => (CultureAssistanceDTO)u).ToList(),
                Shares = data.Shares.Select(u => (ShareDTO)u).ToList(),
                Chat = data.Chat,
                Title = data.Title,
                Description = data.Description,
                TargetCountry = data.TargetCountry,
                MaxParticipant = data.MaxParticipant,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CreateDate = data.CreateDate,
                InviteLink = data.InviteLink,
            };
        }
    }
}
