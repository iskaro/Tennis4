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

namespace Tennis4.Controllers
{
    public class CompetitionEnrollmentController : Controller
    {
        private TennisContext db = new TennisContext();

        // GET: /CompetitionEnrollment/
        public ActionResult Index()
        {
            //var competitionenrollments = db.CompetitionEnrollments.Include(c => c.CompetitionRow).Include(c => c.Player);

            //var query = (from ce in db.CompetitionEnrollments
            //             join p in db.Players on ce.PlayerID equals p.ID
            //             join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
            //             join c in db.Competitions on cr.CompetitionID equals c.ID
            //             where ce.PlayerID == p.ID
            //             select );

           
            var query = from p in db.Players
                        join ce in db.CompetitionEnrollments on p.ID equals ce.PlayerID
                        join cr in db.CompetitionRows on ce.CompetitionRowID equals cr.ID
                        join c in db.Competitions on cr.CompetitionID equals c.ID
                        select new PlayerPosition
                        {
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            CompetitionName = c.CompetitionName,
                            RowNumber = cr.RowNumber
                        };

            IEnumerable<PlayerPosition> data = query;
            ViewBag.PlayerPosition = data;

            return View();
        }

        // GET: /CompetitionEnrollment/Details/5
        public ActionResult Details(int? id)
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
            return View(competitionenrollment);
        }

        // GET: /CompetitionEnrollment/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionRowID = new SelectList(db.CompetitionRows, "ID", "ID");
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName");
            return View();
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
            CompetitionEnrollment competitionenrollment = db.CompetitionEnrollments.Find(id);
            if (competitionenrollment == null)
            {
                return HttpNotFound();
            }
            return View(competitionenrollment);
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
