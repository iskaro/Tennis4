using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tennis4.Models
{
    public class Round
    {
        public int ID { get; set; }
        public int CompetitionID { get; set; }
        public int RoundNumber { get; set; }
        public int AttackerOddEvenID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
        public virtual Competition Competition { get; set; }
        public virtual ICollection<CompetitionRow> Rows { get; set; }
    }
}