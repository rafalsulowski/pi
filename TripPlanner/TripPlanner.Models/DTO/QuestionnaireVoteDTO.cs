using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.DTO
{
    public class QuestionnaireVoteDTO
    {
        public int UserId { get; set; }
        public int QuestionnaireAnswerId { get; set; }
    }
}
