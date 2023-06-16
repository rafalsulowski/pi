﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPlanner.Models.Models
{
    public class CheckList
    {
        public int Id { get; set; }
        
        public User User { get; set; } = null!;
        public int UserID { get; set; }
        public Tour Tour { get; set; } = null!;
        public int TourID { get; set; }
        public ICollection<CheckListField> Fields { get; } = new List<CheckListField>();


        public string Name { get; set; } = string.Empty;
        public bool IsPublic { get; set; }
    }
}
