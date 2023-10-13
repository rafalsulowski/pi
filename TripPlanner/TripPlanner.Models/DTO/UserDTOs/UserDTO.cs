
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.DTO.BudgetDTOs;
using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Models.DTO.GroupDTOs;
using TripPlanner.Models.DTO.QuestionnaireDTOs;
using TripPlanner.Models.DTO.RouteDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.Models.Message;

namespace TripPlanner.Models.DTO.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public ICollection<CheckListDTO> CheckLists { get; set; } = new List<CheckListDTO>();
        public ICollection<OrganizerTourDTO> OrganizerTours { get; set; } = new List<OrganizerTourDTO>();
        public ICollection<ParticipantTourDTO> ParticipantTours { get; set; } = new List<ParticipantTourDTO>();
        public ICollection<ContributeBudgetDTO> ParticipantBudgets { get; set; } = new List<ContributeBudgetDTO>();
        public ICollection<QuestionnaireDTO> Questionnaires { get; set; } = new List<QuestionnaireDTO>();
        public ICollection<QuestionnaireVoteDTO> QuestionnaireVotes { get; set; } = new List<QuestionnaireVoteDTO>();
        public ICollection<ParticipantGroupDTO> ParticipantGroups { get; set; } = new List<ParticipantGroupDTO>();
        public ICollection<MessageDTO> Messages { get; set; } = new List<MessageDTO>();
        public ICollection<RouteDTO> Routes { get; set; } = new List<RouteDTO>();
        public ICollection<BillDTO> Bills { get; set; } = new List<BillDTO>();
        public ICollection<ParticipantBillDTO> BillSettle { get; set; } = new List<ParticipantBillDTO>();

        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }


        public static implicit operator User(UserDTO User)
        {
            if (User == null)
                return null;

            return new User
            {
                Id = User.Id,
                CheckLists = User.CheckLists.Select(u => (CheckList)u).ToList(),
                OrganizerTours = User.OrganizerTours.Select(u => (OrganizerTour)u).ToList(),
                ParticipantTours = User.ParticipantTours.Select(u => (ParticipantTour)u).ToList(),
                ParticipantBudgets = User.ParticipantBudgets.Select(u => (ContributeBudget)u).ToList(),
                Questionnaires = User.Questionnaires.Select(u => (Questionnaire)u).ToList(),
                QuestionnaireVotes = User.QuestionnaireVotes.Select(u => (QuestionnaireVote)u).ToList(),
                ParticipantGroups = User.ParticipantGroups.Select(u => (ParticipantGroup)u).ToList(),
                Messages = User.Messages.Select(u => (Message)u).ToList(),
                Routes = User.Routes.Select(u => (Route)u).ToList(),
                Bills = User.Bills.Select(u => (Bill)u).ToList(),
                BillSettle = User.BillSettle.Select(u => (ParticipantBill)u).ToList(),
                Email = User.Email,
                FullName = User.FullName,
                FullAddress = User.FullAddress,
                City = User.City,
                DateOfBirth = User.DateOfBirth,
            };
        }
    }
}
