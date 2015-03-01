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
    public class MatchController : Controller
    {
        private TennisContext db = new TennisContext();

        // GET: /Match/
        public ActionResult Index()
        {
            //var matches = db.Matches.Include(m => m.Round);

            var matchesAndResults = from m in db.Matches
                                    join re in db.Results on m.ID equals re.MatchID
                                    join p in db.Players on re.PlayerID equals p.ID
                                    where m.RoundID == 1
                                    group new PlayerResult
                                    {
                                        PlayerID = p.ID,
                                        PlayerFullName = p.LastName + ", " + p.FirstName,
                                        ScoreSet1 = re.ScoreSet1,
                                        ScoreSet2 = re.ScoreSet2,
                                        ScoreSet3 = re.ScoreSet3
                                    } by m.ID into g
                                    select new MatchesAndResults
                                    {
                                        MatchID = g.Key,
                                        PlayerResult = g.AsEnumerable()
                                    };




            return View(matchesAndResults.ToList());
        }

        // GET: /Match/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // GET: /Match/Create
        public ActionResult Create()
        {
            ViewBag.RoundID = new SelectList(db.Rounds, "ID", "ID");
            return View();
        }

        // POST: /Match/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,RoundID")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Matches.Add(match);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoundID = new SelectList(db.Rounds, "ID", "ID", match.RoundID);
            return View(match);
        }

        // GET: /Match/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoundID = new SelectList(db.Rounds, "ID", "ID", match.RoundID);
            return View(match);
        }

        // POST: /Match/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,RoundID")] Match match)
        {
            if (ModelState.IsValid)
            {
                db.Entry(match).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoundID = new SelectList(db.Rounds, "ID", "ID", match.RoundID);
            return View(match);
        }

        // GET: /Match/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: /Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = db.Matches.Find(id);
            db.Matches.Remove(match);
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
