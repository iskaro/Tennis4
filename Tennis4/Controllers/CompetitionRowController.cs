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
using System.Web.UI;

namespace Tennis4.Controllers
{
    public class CompetitionRowController : Controller
    {
        private TennisContext db = new TennisContext();

        // GET: /CompetitionRow/
        public ActionResult Index(string CompetitionNames)
        {
            //if (CompetitionID == null)
            //{
            //    CompetitionID = currentFilter;
            //}
            
            //ViewBag.CurrentFilter = CompetitionID;
            

            //var competitionrows = from c in db.CompetitionRows
            //                      select c;

            ViewBag.CompetitionNames = new SelectList(db.Competitions, "ID", "CompetitionName");

            //if (!String.IsNullOrEmpty(CompetitionNames))
            //{
            //    competitionrows = competitionrows.Where(s => s.Competition.CompetitionName.Contains(CompetitionID));
            //}

            var listOfRows = db.CompetitionRows.ToList();

            if (!String.IsNullOrEmpty(CompetitionNames))
            {
                int compID = Int32.Parse(CompetitionNames);
                listOfRows = db.CompetitionRows.Where(cr => cr.CompetitionID == compID).ToList();
            }
      
            //var competitionrows = db.CompetitionRows.Include(c => c.Competition);
            return View(listOfRows);
        }

        // GET: /CompetitionRow/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionRow competitionrow = db.CompetitionRows.Find(id);
            if (competitionrow == null)
            {
                return HttpNotFound();
            }
            return View(competitionrow);
        }

        // GET: /CompetitionRow/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionID = new SelectList(db.Competitions, "ID", "CompetitionName");
            return View();
        }

        // POST: /CompetitionRow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,RowNumber,Capacity,CompetitionID")] CompetitionRow competitionrow)
        {
            if (ModelState.IsValid)
            {
                db.CompetitionRows.Add(competitionrow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionID = new SelectList(db.Competitions, "ID", "CompetitionName", competitionrow.CompetitionID);
            return View(competitionrow);
        }

        //public ActionResult AjaxValidation(int rowNumber)
        //{
        //    if (Request.IsAjaxRequest())
        //    {
        //        db.CompetitionRows.Where(row => (row.CompetitionID == CompetitionID)).Any(row => row.RowNumber == RowNumber)
        //    }

        //}

        // GET: /CompetitionRow/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionRow competitionrow = db.CompetitionRows.Find(id);
            if (competitionrow == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionID = new SelectList(db.Competitions, "ID", "CompetitionName", competitionrow.CompetitionID);
            return View(competitionrow);
        }

        // POST: /CompetitionRow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,RowNumber,Capacity,CompetitionID")] CompetitionRow competitionrow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competitionrow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionID = new SelectList(db.Competitions, "ID", "CompetitionName", competitionrow.CompetitionID);
            return View(competitionrow);
        }

        // GET: /CompetitionRow/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetitionRow competitionrow = db.CompetitionRows.Find(id);
            if (competitionrow == null)
            {
                return HttpNotFound();
            }
            return View(competitionrow);
        }

        // POST: /CompetitionRow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetitionRow competitionrow = db.CompetitionRows.Find(id);
            db.CompetitionRows.Remove(competitionrow);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        [HttpPost]
        
        public JsonResult doesRowInCompetitionExist(int RowNumber, int? CompetitionID)
        {
            return Json(!db.CompetitionRows.Where(row => (row.CompetitionID == CompetitionID)).Any(row => row.RowNumber == RowNumber), JsonRequestBehavior.AllowGet);
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
