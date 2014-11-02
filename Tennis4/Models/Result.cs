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
        public int RoundID { get; set; }
        public int Player1ID { get; set; }
        public int Player2ID { get; set; }
        public int Player1SetOneScore { get; set; }
        public int Player2SetOneScore { get; set; }
        public int Player1SetTwoScore { get; set; }
        public int Player2SetTwoScore { get; set; }
        public int Player1SetThreeScore { get; set; }
        public int Player2SetThreeScore { get; set; }
        public int Player1SetFourScore { get; set; }
        public int Player2SetFourScore { get; set; }
        public int Player1SetFiveScore { get; set; }
        public int Player2SetFiveScore { get; set; }

        public virtual Round Round { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}