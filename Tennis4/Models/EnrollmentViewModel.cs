using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tennis4.Models
{
    //public class EnrollmentViewModel
    //{
    //    public IList<RowView> Rows { get; set; }
    //    public IList<PlayerView> Players { get; set; }
    //}

    public class PlayerView
    {
        public int PlayerID { get; set; }
        public string PlayerFullName { get; set; }
    }

    public class RowViewModel
    {
        public int RowNumber { get; set; }
        public PlayerView Players { get; set; }
    }
}