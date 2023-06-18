using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        
        public ICollection<CheckListDTO> CheckLists { get; } = new List<CheckListDTO>();
        public ICollection<ParticipantTourDTO> OrganizerTours { get; } = new List<ParticipantTourDTO>();
        public ICollection<ParticipantTourDTO> ParticipantTours { get; } = new List<ParticipantTourDTO>();
        public ICollection<ContributesBudgetDTO> ParticipantBudgets { get; } = new List<ContributesBudgetDTO>();
        public ICollection<QuestionnaireDTO> Questionnaires { get; } = new List<QuestionnaireDTO>();
        public ICollection<QuestionnaireVoteDTO> QuestionnaireVotes { get; } = new List<QuestionnaireVoteDTO>();
        public ICollection<ParticipantGroupDTO> ParticipantGroups { get; } = new List<ParticipantGroupDTO>();
        public ICollection<MessageDTO> Messages { get; } = new List<MessageDTO>();
        public ICollection<RouteDTO> Routes { get; } = new List<RouteDTO>();
        public ICollection<BillDTO> Bills { get; } = new List<BillDTO>();
        public ICollection<ParticipantBillDTO> BillSettle { get; } = new List<ParticipantBillDTO>();

        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}
