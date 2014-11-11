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
            ViewBag.roundId = new SelectList(db.Rounds, "ID", "RoundNumber", roundId);

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

            var players = from p in db.Players
                          join ce in db.CompetitionEnrollments on p.ID equals ce.PlayerID
                          join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
                          where cr.Round.CompetitionID == competitionId
                          select new PlayerViewModel
                          {
                              PlayerID = p.ID,
                              PlayerFullName = p.LastName + ", " + p.FirstName
                          };

            ViewBag.Players = players.AsEnumerable();

            int capacity = (from c in db.Competitions
                               where c.ID == competitionId
                               select c.RowCapacity).Single();

            ViewBag.Capacity = capacity;
            
            return View(players.AsEnumerable());
        }
	}
}