using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tennis4.Models
{
    public class Match
    {
        public int ID { get; set; }
        public int RoundID { get; set; }

        //public int sdfsd { get; set; }
        
        public virtual Round Round { get; set; }
    }
}