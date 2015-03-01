using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tennis4.Models;
using Tennis4.DAL;
using System.Data.Entity.SqlServer;

namespace Tennis4.Controllers
{
    public class CompetitionEnrollmentController : Controller
    {
        private TennisContext db = new TennisContext();

        // GET: /CompetitionEnrollment/
        public ActionResult Index()
        {
            var competitionenrollments = db.CompetitionEnrollments;
          
            var query = from p in db.Players
                        join ce in db.CompetitionEnrollments on p.ID equals ce.PlayerID
                        join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
                        join c in db.Competitions on cr.Round.CompetitionID equals c.ID
                        select new PlayerPositionModel
                        {
                            CompetitionEnrollmentID = ce.ID,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            CompetitionName = c.CompetitionName,
                            RoundNumber = cr.Round.RoundNumber,
                            RowNumber = cr.RowNumber,
                            CompetitionRowPosition = ce.CompetitionRowPosition
                        };

            ViewBag.PlayerPositionModel = query.AsEnumerable();

            return View(competitionenrollments);
        }

        // GET: /CompetitionEnrollment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var query = (from p in db.Players
                        join ce in db.CompetitionEnrollments on p.ID equals ce.PlayerID
                        join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
                        join ro in db.Rounds on cr.RoundID equals ro.ID
                        join c in db.Competitions on ro.CompetitionID equals c.ID
                        where ce.ID == id
                        select new PlayerPositionModel
                        {
                            CompetitionEnrollmentID = ce.ID,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            CompetitionName = c.CompetitionName,
                            RowNumber = cr.RowNumber
                        }).Single();

            return View(query);
        }

        // GET: /CompetitionEnrollment/Create
        public ActionResult Create()
        {

            //**** Send list of players for dropdown list ****
            var playerQuery = from p in db.Players
                              select new PlayerIdLastNameFirstName
                              {
                                  ID = p.ID,
                                  LastNameFirstName = p.LastName + ", " + p.FirstName
                              };
            ViewBag.PlayerID = new SelectList(playerQuery, "ID", "LastNameFirstName");

            //***** Select list of competitions for dropdown list ****
            ViewBag.CompetitionListID = new SelectList(db.Competitions.AsEnumerable(), "ID", "CompetitionName");



            return View();
        }

        // JSON: /CompetitionEnrollment/Create
        public JsonResult GetRounds(int Id)
        {
            var queryRounds = from ro in db.Rounds
                            where ro.CompetitionID == Id
                            select new
                            {
                                value = ro.ID,
                                text = ro.RoundNumber + ": "
                                + ro.DateFrom.Day + "." + ro.DateFrom.Month + "." + ro.DateFrom.Year + "." + "-"
                                + ro.DateTo.Day + "." + ro.DateTo.Month + "." + ro.DateTo.Year + ".",
                            };

            var listOfRounds = new SelectList(queryRounds.AsEnumerable(), "value", "text");

            return Json(listOfRounds, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetRows (int Id) 
        {
            var queryRows = from cr in db.CompetitionRows
                            where cr.RoundID == Id
                            select new
                            {
                                cr.ID,
                                cr.RowNumber,
                            };

            var listOfRows = new SelectList(queryRows.AsEnumerable(), "ID", "RowNumber");

            return Json(listOfRows, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRowPositions(int Id)
        {
            var queryRowPositions = (from c in db.Competitions
                                     where c.ID == Id
                                     select c.RowCapacity).Single();

            List<SelectListItem> capacityList = new List<SelectListItem>();

            for (int i = 1; i <= queryRowPositions; i++)
            {
                capacityList.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }



            return Json(capacityList.AsEnumerable(), JsonRequestBehavior.AllowGet);
        }

        // POST: /CompetitionEnrollment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PlayerID,CompetitionRowID")] CompetitionEnrollment competitionenrollment)
        {
            if (ModelState.IsValid)
            {
                db.CompetitionEnrollments.Add(competitionenrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionRowID = new SelectList(db.CompetitionRows, "ID", "ID", competitionenrollment.CompetitionRowID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName", competitionenrollment.PlayerID);
            return View(competitionenrollment);
        }

        // GET: /CompetitionEnrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionEnrollment competitionenrollment = db.CompetitionEnrollments.Find(id);
            if (competitionenrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionRowID = new SelectList(db.CompetitionRows, "ID", "ID", competitionenrollment.CompetitionRowID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName", competitionenrollment.PlayerID);
            return View(competitionenrollment);
        }

        // POST: /CompetitionEnrollment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PlayerID,CompetitionRowID")] CompetitionEnrollment competitionenrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competitionenrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionRowID = new SelectList(db.CompetitionRows, "ID", "ID", competitionenrollment.CompetitionRowID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName", competitionenrollment.PlayerID);
            return View(competitionenrollment);
        }

        // GET: /CompetitionEnrollment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var query = (from p in db.Players
                         join ce in db.CompetitionEnrollments on p.ID equals ce.PlayerID
                         join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
                         join c in db.Competitions on cr.Round.CompetitionID equals c.ID
                         where ce.ID == id
                         select new PlayerPositionModel
                         {
                             CompetitionEnrollmentID = ce.ID,
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             CompetitionName = c.CompetitionName,
                             RowNumber = cr.RowNumber
                         }).Single();

            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // POST: /CompetitionEnrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetitionEnrollment competitionenrollment = db.CompetitionEnrollments.Find(id);
            db.CompetitionEnrollments.Remove(competitionenrollment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
