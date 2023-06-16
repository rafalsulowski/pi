using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class Tour
    {
        public int Id { get; set; }

        public ICollection<ParticipantTour> Participants { get; } = new List<ParticipantTour>();
        public ICollection<ParticipantTour> Organizers { get; } = new List<ParticipantTour>();
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

        
    }
}
