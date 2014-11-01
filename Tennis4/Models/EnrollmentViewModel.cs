using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tennis4.Models
{
    public class EnrollmentViewModel
    {
        public IEnumerable<Player> Players { get; set; }
        public int CompetitionID { get; set; }
        public string CompetitionName { get; set; }
        public int CompetitionRowID { get; set; }
        public int RowNumber { get; set; }
    }
}