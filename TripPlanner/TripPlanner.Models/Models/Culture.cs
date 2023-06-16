using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class Culture
    {
        public int Id { get; set; }

        public ICollection<CultureAssistance> Tours { get; } = new List<CultureAssistance>();

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Goverment { get; set; } = string.Empty;
        public string GeograpInformation { get; set; } = string.Empty;
        public string Manners { get; set; } = string.Empty;
        public string LanguageAssistance { get; set; } = string.Empty;
        public string ProperBehaviour { get; set; } = string.Empty;
    }
}
