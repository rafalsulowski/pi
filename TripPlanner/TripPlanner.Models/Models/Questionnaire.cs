﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class Questionnaire
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;
        public int UserID { get; set; }
        public Tour Tour { get; set; } = null!;
        public int TourID { get; set; }
        public Chat Chat { get; set; } = null!;
        public int ChatID { get; set; }
        public ICollection<QuestionnaireAnswer> Answers { get; } = new List<QuestionnaireAnswer>();

        public string Question { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
