using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public ICollection<CheckList> CheckLists { get; } = new List<CheckList>();
        public ICollection<OrganizeTour> OrganizerTours { get; } = new List<OrganizeTour>();
        public ICollection<ParticipantTour> ParticipantTours { get; } = new List<ParticipantTour>();
        public ICollection<ContributesBudget> ParticipantBudgets { get; } = new List<ContributesBudget>();
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
    }
}
