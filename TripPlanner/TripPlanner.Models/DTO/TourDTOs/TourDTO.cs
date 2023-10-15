
using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Models.DTO.RouteDTOs;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.Models.CheckListModels;
using TripPlanner.Models.Models.MessageModels.QuestionnaireModels;
using TripPlanner.Models.Models.RouteModels;
using TripPlanner.Models.Models.TourModels;
using TripPlanner.Models.DTO.CultureDTOs;
using TripPlanner.Models.Models.CultureModels;

namespace TripPlanner.Models.DTO.TourDTOs
{
    public class TourDTO
    {
        public int Id { get; set; }

        public ICollection<ParticipantTourDTO> Participants { get; set; } = new List<ParticipantTourDTO>();
        public ICollection<CheckListDTO> CheckLists { get; set; } = new List<CheckListDTO>();
        public ICollection<QuestionnaireDTO> Questionnaires { get; set; } = new List<QuestionnaireDTO>();
        public ICollection<RouteDTO> Routes { get; set; } = new List<RouteDTO>();
        public ICollection<CultureAssistanceDTO> Cultures { get; set; } = new List<CultureAssistanceDTO>();
        public ChatDTO Chat { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TargetCountry { get; set; } = string.Empty;
        public int MaxParticipant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string InviteLink { get; set; } = string.Empty;


        public static implicit operator Tour(TourDTO data)
        {
            if (data == null)
                return null;

            return new Tour
            {
                Id = data.Id,
                Participants = data.Participants.Select(u => (ParticipantTour)u).ToList(),
                CheckLists = data.CheckLists.Select(u => (CheckList)u).ToList(),
                Questionnaires = data.Questionnaires.Select(u => (Questionnaire)u).ToList(),
                Routes = data.Routes.Select(u => (Route)u).ToList(),
                Cultures = data.Cultures.Select(u => (CultureAssistance)u).ToList(),
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
