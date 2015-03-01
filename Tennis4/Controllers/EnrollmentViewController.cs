using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tennis4.DAL;
using Tennis4.Models;

namespace Tennis4.Controllers
{
    public class EnrollmentViewController : Controller
    {
        private TennisContext db = new TennisContext();

        //
        // GET: /EnrollmentView/
        public ActionResult Index(int? competitionId, int? roundId)
        {
            if (competitionId == null)
            {
                competitionId = 1;
                roundId = 1;
            }

            ViewBag.competitionId = new SelectList(db.Competitions, "ID", "CompetitionName", competitionId);

            var playerQuery = (from cr in db.CompetitionRows
                         join ce in db.CompetitionEnrollments on cr.ID equals ce.CompetitionRowID
                         where cr.Round.CompetitionID == competitionId
                         where cr.Round.ID == roundId
                         group ce.PlayerID by cr.RowNumber into g
                               select new RowViewModel
                         {
                             RowNumber = g.Key,
                             ListPlayerIds = g.ToList()
                         });
            ViewBag.RowsAndIds = playerQuery;

            var playersAndResults = from p in db.Players
                                    join re in db.Results on p.ID equals re.PlayerID
                                    join ma in db.Matches on re.MatchID equals ma.ID
                                    where ma.RoundID == roundId
                                    where ma.Round.CompetitionID == competitionId
                                    select new PlayerViewModel
                                    {
                                        PlayerID = p.ID,
                                        PlayerFullName = p.LastName + ", " + p.FirstName,
                                        ScoreSet1 = re.ScoreSet1
                                    };
            ViewBag.Players = playersAndResults.AsEnumerable();

            int capacity = (from c in db.Competitions
                               where c.ID == competitionId
                               select c.RowCapacity).Single();

            ViewBag.Capacity = capacity;



            return View(playersAndResults.AsEnumerable());
        }
	}
}