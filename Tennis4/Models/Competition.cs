using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tennis4.Models
{
    public class Competition
    {
        public string CompetitionID;
        public int ID { get; set; }
        public string CompetitionName { get; set; }

        public virtual ICollection<CompetitionRow> CompetitionRows { get; set; }
    }
}
