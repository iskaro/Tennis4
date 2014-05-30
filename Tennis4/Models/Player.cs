using System;
using System.Collections.Generic;

namespace Tennis4.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual ICollection<CompetitionEnrollment> CompetitionEnrollments { get; set; }
    }
}