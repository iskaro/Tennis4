using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Tennis4.Models
{
    public class CompetitionRow
    {
        public int ID { get; set; }
        public int CompetitionID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than 1")]
        [Remote("doesRowInCompetitionExist", "CompetitionRow", AdditionalFields = "CompetitionID", HttpMethod = "POST", ErrorMessage = "Row already exists. Please enter a different.")]
        public int RowNumber { get; set; }

        [Range(1, 100)]
        public int Capacity { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual ICollection<CompetitionEnrollment> CompetitionEnrollment { get; set; }
    }
}