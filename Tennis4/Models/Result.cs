using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tennis4.Models
{
    public class Result
    {
        public int ID { get; set; }
        public int MatchID { get; set; }
        public int PlayerID { get; set; }
        public int ScoreSet1 { get; set; }
        public int ScoreSet2 { get; set; }
        public int ScoreSet3 { get; set; }
        public virtual Player Player { get; set; }
        public virtual Match Match { get; set; }
    }
}