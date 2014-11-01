using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tennis4.Models
{
    public class Player
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DayOfBirth { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual ICollection<CompetitionEnrollment> CompetitionEnrollments { get; set; }
    }
}