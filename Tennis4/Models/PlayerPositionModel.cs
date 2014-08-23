using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tennis4.Models
{
    public class PlayerPositionModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompetitionName { get; set; }
        public int RowNumber { get; set; }
    }

    public class ModelCast
    {
        public IEnumerable<PlayerPositionModel> PlayerPositions { get; set; }
    }
}