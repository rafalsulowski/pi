using TripPlanner.Models.DTO;
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Models.DTO.UserDTOs;

namespace TripPlanner.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public ICollection<CheckList> CheckLists { get; set; } = new List<CheckList>();
        public ICollection<OrganizeTour> OrganizerTours { get; set; } = new List<OrganizeTour>();
        public ICollection<ParticipantTour> ParticipantTours { get; set; } = new List<ParticipantTour>();
        public ICollection<ContributeBudget> ParticipantBudgets { get; set; } = new List<ContributeBudget>();
        public ICollection<Questionnaire> Questionnaires { get; set; } = new List<Questionnaire>();
        public ICollection<QuestionnaireVote> QuestionnaireVotes { get; set; } = new List<QuestionnaireVote>();
        public ICollection<ParticipantGroup> ParticipantGroups { get; set; } = new List<ParticipantGroup>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<Route> Routes { get; set; } = new List<Route>();
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
        public ICollection<ParticipantBill> BillSettle { get; set; } = new List<ParticipantBill>();

        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }


        public static implicit operator UserDTO(User User)
        {
            if (User == null)
                return null;

            return new UserDTO
            {
                Id = User.Id,
                CheckLists = User.CheckLists.Select(u => (CheckListDTO)u).ToList(),
                OrganizerTours = User.OrganizerTours.Select(u => (OrganizeTourDTO)u).ToList(),
                ParticipantTours = User.ParticipantTours.Select(u => (ParticipantTourDTO)u).ToList(),
                ParticipantBudgets = User.ParticipantBudgets.Select(u => (ContributeBudgetDTO)u).ToList(),
                Questionnaires = User.Questionnaires.Select(u => (QuestionnaireDTO)u).ToList(),
                QuestionnaireVotes = User.QuestionnaireVotes.Select(u => (QuestionnaireVoteDTO)u).ToList(),
                ParticipantGroups = User.ParticipantGroups.Select(u => (ParticipantGroupDTO)u).ToList(),
                Messages = User.Messages.Select(u => (MessageDTO)u).ToList(),
                Routes = User.Routes.Select(u => (RouteDTO)u).ToList(),
                Bills = User.Bills.Select(u => (BillDTO)u).ToList(),
                BillSettle = User.BillSettle.Select(u => (ParticipantBillDTO)u).ToList(),
                Email = User.Email,
                Name = User.Name,
                Surname = User.Surname,
                PasswordHash = User.PasswordHash,
                Address = User.Address,
                DateOfBirth = User.DateOfBirth
            };
        }
    }
}
