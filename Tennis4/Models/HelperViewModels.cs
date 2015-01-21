using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tennis4.Models
{
    public class PlayerPositionModel
    {
        public int CompetitionEnrollmentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompetitionName { get; set; }
        public int RoundNumber { get; set; }
        public int RowNumber { get; set; }
        public int CompetitionRowPosition { get; set; }
    }

    public class ModelCast
    {
        public IEnumerable<PlayerPositionModel> PlayerPositions { get; set; }
        public IQueryable<PlayerPositionModel> playerPositionsModel { get; set; }
    }

    public class PlayerIdLastNameFirstName
    {
        public int ID { get; set; }
        public string LastNameFirstName { get; set; }
    }

    public class PlayerViewModel
    {
        public int PlayerID { get; set; }
        public string PlayerFullName { get; set; }
    }

    public class RowViewModel
    {
        public int RowNumber { get; set; }
        public List<int> ListPlayerIds { get; set; }
    }

    //public class ResultsViewListModel
    //{
    //    public int ResultID { get; set; }
    //    public int RoundID { get; set; }
    //    public string Player1FullName { get; set; }
    //    public string Player2FullName { get; set; }
    //    public int Player1SetOneScore { get; set; }
    //    public int Player2SetOneScore { get; set; }
    //    public int Player1SetTwoScore { get; set; }
    //    public int Player2SetTwoScore { get; set; }
    //    public int Player1SetThreeScore { get; set; }
    //    public int Player2SetThreeScore { get; set; }
    //    public int Player1SetFourScore { get; set; }
    //    public int Player2SetFourScore { get; set; }
    //    public int Player1SetFiveScore { get; set; }
    //    public int Player2SetFiveScore { get; set; }
    //}
}