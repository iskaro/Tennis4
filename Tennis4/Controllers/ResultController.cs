﻿using System;
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
        public ActionResult Index()
        {
            var results = db.Results.Include(r => r.Match).Include(r => r.Player);
            return View(results.ToList());
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
    }
}
