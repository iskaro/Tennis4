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

            //var playersQuery = (from p in db.Players
            //                    join ce in db.CompetitionEnrollments on p.ID equals ce.PlayerID
            //                    join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
            //                    join c in db.Competitions on cr.CompetitionID equals c.ID
            //                    where c.ID == competitionId
            //                    select p);

            //var capacity = (from c in db.Competitions
            //                where c.ID == competitionId
            //                select c.RowCapacity).Single();

            var listOfRows = (from cr in db.CompetitionRows
                              where cr.CompetitionID == competitionId
                              select cr.RowNumber);

            //ViewBag.Players = playersQuery.ToList();

            //EnrollmentViewModel model = new EnrollmentViewModel
            //{
            //    Players = playersQuery,
            //    RowNumber = listOfRows.ToList(),
            //    Capacity = capacity
            //};



            var playerQuery = (from p in db.Players
                                join ce in db.CompetitionEnrollments on p.ID equals ce.PlayerID
                                join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
                                join c in db.Competitions on cr.CompetitionID equals c.ID
                                where c.ID == competitionId
                                select new RowViewModel
                                {
                                    RowNumber = cr.RowNumber,
                                    Players = new PlayerView
                                    {
                                        PlayerID = p.ID,
                                        PlayerFullName = p.LastName + ", " + p.FirstName                                        
                                    }
                                });

             Dictionary<int, PlayerView> = new Dictionary<int, PlayerView>()
             {
                 {1, new PlayerView {PlayerID = 1, PlayerFullName = "asdadad"}}
             };
          



            return View(playerQuery.AsEnumerable());
        }
	}
}