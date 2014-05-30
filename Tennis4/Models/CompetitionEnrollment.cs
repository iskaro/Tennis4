
namespace Tennis4.Models
{
    public class CompetitionEnrollment
    {
        public int ID { get; set; }
        public int PlayerID { get; set; }
        public int CompetitionRowID { get; set; }

        public virtual Player Player { get; set; }
        public virtual CompetitionRow CompetitionRow { get; set; }
    }
}
