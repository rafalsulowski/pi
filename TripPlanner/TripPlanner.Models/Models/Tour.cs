using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO;

namespace TripPlanner.Models.Models
{
    public class Tour
    {
        public int Id { get; set; }

        public ICollection<OrganizeTour> Organizers { get; } = new List<OrganizeTour>();
        public ICollection<ParticipantTour> Participants { get; } = new List<ParticipantTour>();
        public ICollection<CheckList> CheckLists { get; } = new List<CheckList>();
        public ICollection<Questionnaire> Questionnaires { get; } = new List<Questionnaire>();
        public ICollection<Group> Groups { get; } = new List<Group>();
        public ICollection<Route> Routes { get; } = new List<Route>();
        public ICollection<Bill> Bills { get; } = new List<Bill>();
        public ICollection<CultureAssistance> CultureAssistances { get; } = new List<CultureAssistance>();
        public Budget? Budget { get; set; }

        public string Title { get; set; } = string.Empty;
        public string TargetCountry { get; set; } = string.Empty;
        public int MaxParticipant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }        

        public TourDTO MapToDTO()
        {
            return new TourDTO
            {
                Id = Id,
                Organizers = Organizers.Select(u => u.MapToDTO()).ToList(),
                Participants = Participants.Select(u => u.MapToDTO()).ToList(),
                CheckLists = CheckLists.Select(u => u.MapToDTO()).ToList(),
                Questionnaires = Questionnaires.Select(u => u.MapToDTO()).ToList(),
                Routes = Routes.Select(u => u.MapToDTO()).ToList(),
                Groups = Groups.Select(u => u.MapToDTO()).ToList(),
                Bills = Bills.Select(u => u.MapToDTO()).ToList(),
                CultureAssistances = CultureAssistances.Select(u => u.MapToDTO()).ToList(),
                Budget = Budget != null ? Budget.MapToDTO() : null,
                Title = Title,
                TargetCountry = TargetCountry,
                MaxParticipant = MaxParticipant,
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}
