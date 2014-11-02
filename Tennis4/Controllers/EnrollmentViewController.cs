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
        public ActionResult Index(int? competitionId)
        {           
            ViewBag.competitionId = new SelectList(db.Competitions, "ID", "CompetitionName");

            var playerQuery = (from cr in db.CompetitionRows
                         join ce in db.CompetitionEnrollments on cr.ID equals ce.CompetitionRowID
                         where cr.CompetitionID == competitionId
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
                          where cr.CompetitionID == competitionId
                          select new PlayerViewModel
                          {
                              PlayerID = p.ID,
                              PlayerFullName = p.LastName + ", " + p.FirstName
                          };

            ViewBag.Players = players.AsEnumerable();

            var capacity = (from c in db.Competitions
                               where c.ID == competitionId
                               select c.RowCapacity).ToString();
            int numValue;

            Int32.TryParse(capacity, out numValue);

            ViewBag.Capacity = numValue;
            
            return View(players.AsEnumerable());
        }
	}
}