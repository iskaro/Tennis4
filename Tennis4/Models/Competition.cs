using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tennis4.Models
{
    public class Competition
    {
        public int ID { get; set; }
        public string CompetitionName { get; set; }

        [Range(1, 100)]
        public int RowCapacity { get; set; }
        public int SetsNumber { get; set; }
        public int GamesNumber { get; set; }

        public virtual ICollection<CompetitionRow> CompetitionRows { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }
    }
}
