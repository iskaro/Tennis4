using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tennis4.Models
{
    public class PlayerPosition
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompetitionName { get; set; }
        public int RowNumber { get; set; }
    }
}