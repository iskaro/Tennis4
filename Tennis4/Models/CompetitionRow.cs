using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tennis4.Models
{
    public class CompetitionRow
    {
        public int ID { get; set; }
        public int Row { get; set; }

        public virtual ICollection<CompetitionEnrollment> CompetitionEnrollments { get; set; }
    }
}