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
            var playersQuery = (from p in db.Players
                                    join ce in db.CompetitionEnrollments on p.ID equals ce.PlayerID
                                    join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
                                    join c in db.Competitions on cr.CompetitionID equals c.ID
                                        //where c.ID == competitionId
                                        select p);

            ViewBag.Players = playersQuery.AsEnumerable();
                   
            var modelQuery = (from p in db.Players
                              join ce in db.CompetitionEnrollments on p.ID equals ce.PlayerID
                              join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
                              join c in db.Competitions on cr.CompetitionID equals c.ID
                              select new EnrollmentViewModel {
                                Players = playersQuery.AsEnumerable(),
                                CompetitionID = c.ID,
                                CompetitionName = c.CompetitionName,
                                CompetitionRowID = cr.ID,
                                RowNumber = cr.RowNumber
                              });

            return View(modelQuery.AsEnumerable());
        }
	}
}