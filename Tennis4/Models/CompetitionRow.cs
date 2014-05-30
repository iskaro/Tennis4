using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tennis4.Models
{
    public class CompetitionRow
    {
        public int ID { get; set; }
        public int RowName { get; set; }
        public int Capacity { get; set; }
        public int CompetitionID { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual ICollection<CompetitionEnrollment> CompetitionEnrollment { get; set; }
    }
}