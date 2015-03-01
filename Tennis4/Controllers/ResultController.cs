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
    public class ResultController : Controller
    {
        private TennisContext db = new TennisContext();

        // GET: /Result/
        public ActionResult Index(int? competitionId, int? roundId)
        {
            //GET Competition dropdown list
            ViewBag.competitionId = new SelectList(db.Competitions, "ID", "CompetitionName", competitionId);


            //GET results
            var results = db.Results.Include(r => r.Match).Include(r => r.Player).Where(x => x.Match.RoundID == roundId).ToList();

            //GET row numbers
            var rowPositions = GetPlayerAndRowNumber();
            ViewBag.RowPositions = rowPositions;

            return View(results);
        }

        [HttpPost]
        public ActionResult Index(FormCollection c, int? competitionId, int? roundId)
        {
            //GET Competition dropdown list
            ViewBag.competitionId = new SelectList(db.Competitions, "ID", "CompetitionName", competitionId);

            //GET results
            var results = db.Results.Include(r => r.Match).Include(r => r.Player).Where(x => x.Match.RoundID == roundId).ToList();

            //GET row numbers
            var rowPositions = GetPlayerAndRowNumber();
            ViewBag.RowPositions = rowPositions;

            //POST save changes
            int i = 0;
            if (ModelState.IsValid)
            {
                var resultIDArray = c.GetValues("item.ID");
                var scoreSet1Array = c.GetValues("item.ScoreSet1");
                var scoreSet2Array = c.GetValues("item.ScoreSet2");
                var scoreSet3Array = c.GetValues("item.ScoreSet3");

                for (i = 0; i < resultIDArray.Count(); i++)
                {
                    Result result = db.Results.Find(Convert.ToInt32(resultIDArray[i]));
                    result.ScoreSet1 = Convert.ToInt32(scoreSet1Array[i]);
                    result.ScoreSet2 = Convert.ToInt32(scoreSet2Array[i]);
                    result.ScoreSet3 = Convert.ToInt32(scoreSet3Array[i]);
                    db.Entry(result).State = EntityState.Modified;
                }
                db.SaveChanges();
            }

            return View(results);
        }

        // GET: /Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: /Result/Create
        public ActionResult Create()
        {
            ViewBag.MatchID = new SelectList(db.Matches, "ID", "ID");
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName");
            return View();
        }

        // POST: /Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,MatchID,PlayerID,ScoreSet1,ScoreSet2,ScoreSet3")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchID = new SelectList(db.Matches, "ID", "ID", result.MatchID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName", result.PlayerID);
            return View(result);
        }

        // GET: /Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchID = new SelectList(db.Matches, "ID", "ID", result.MatchID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName", result.PlayerID);
            return View(result);
        }

        // POST: /Result/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,MatchID,PlayerID,ScoreSet1,ScoreSet2,ScoreSet3")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatchID = new SelectList(db.Matches, "ID", "ID", result.MatchID);
            ViewBag.PlayerID = new SelectList(db.Players, "ID", "FirstName", result.PlayerID);
            return View(result);
        }

        // GET: /Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: /Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Result result = db.Results.Find(id);
            db.Results.Remove(result);
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

        public List<PlayerAndRowNumber> GetPlayerAndRowNumber()
        {
            var rowPositions = (from cr in db.CompetitionRows
                                join ce in db.CompetitionEnrollments on cr.ID equals ce.CompetitionRowID
                                where cr.RoundID == 1
                                select new PlayerAndRowNumber
                                {
                                    PlayerID = ce.PlayerID,
                                    RowNumber = cr.RowNumber
                                }).ToList();
            return rowPositions;
        }
    }
}
