using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public ICollection<CheckList> CheckLists { get; } = new List<CheckList>();
        public ICollection<OrganizeTour> OrganizerTours { get; } = new List<OrganizeTour>();
        public ICollection<ParticipantTour> ParticipantTours { get; } = new List<ParticipantTour>();
        public ICollection<ContributeBudget> ParticipantBudgets { get; } = new List<ContributeBudget>();
        public ICollection<Questionnaire> Questionnaires { get; } = new List<Questionnaire>();
        public ICollection<QuestionnaireVote> QuestionnaireVotes { get; } = new List<QuestionnaireVote>();
        public ICollection<ParticipantGroup> ParticipantGroups { get; } = new List<ParticipantGroup>();
        public ICollection<Message> Messages { get; } = new List<Message>();
        public ICollection<Route> Routes { get; } = new List<Route>();
        public ICollection<Bill> Bills { get; } = new List<Bill>();
        public ICollection<ParticipantBill> BillSettle { get; } = new List<ParticipantBill>();

        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }



        public UserDTO MapToDTO()
        {
            return new UserDTO
            {
                Id = Id,
                CheckLists = CheckLists.Select(u => u.MapToDTO()).ToList(),
                OrganizerTours = OrganizerTours.Select(u => u.MapToDTO()).ToList(),
                ParticipantTours = ParticipantTours.Select(u => u.MapToDTO()).ToList(),
                ParticipantBudgets = ParticipantBudgets.Select(u => u.MapToDTO()).ToList(),
                Questionnaires = Questionnaires.Select(u => u.MapToDTO()).ToList(),
                QuestionnaireVotes = QuestionnaireVotes.Select(u => u.MapToDTO()).ToList(),
                ParticipantGroups = ParticipantGroups.Select(u => u.MapToDTO()).ToList(),
                Messages = Messages.Select(u => u.MapToDTO()).ToList(),
                Routes = Routes.Select(u => u.MapToDTO()).ToList(),
                Bills = Bills.Select(u => u.MapToDTO()).ToList(),
                BillSettle = BillSettle.Select(u => u.MapToDTO()).ToList(),
                Email = Email,
                Username = Username,
                PasswordHash = PasswordHash,
                Address = Address,
                DateOfBirth = DateOfBirth
            };
        }
    }
}
