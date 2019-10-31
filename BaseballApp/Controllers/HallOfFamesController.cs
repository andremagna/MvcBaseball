using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseballApp.Models;
using DAL;

namespace BaseballApp.Controllers
{
    public class HallOfFamesController : Controller
    {
        private BaseballDataEntities db = new BaseballDataEntities();

        // GET: HallOfFames
        public ActionResult Index()
        {
            return View(db.HallOfFame.SqlQuery("SELECT TOP 50 * FROM[dbo].[HallOfFame] order by votes DESC;"));
            //return View(db.HallOfFame.ToList());
        }

        // GET: HallOfFames/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallOfFame hallOfFame = db.HallOfFame.Find(id);
            if (hallOfFame == null)
            {
                return HttpNotFound();
            }
            return View(hallOfFame);
        }

        // GET: HallOfFames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HallOfFames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hofID,yearID,votedBy,ballots,needed,votes,inducted,category,needed_note")] HallOfFame hallOfFame)
        {
            if (ModelState.IsValid)
            {
                db.HallOfFame.Add(hallOfFame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hallOfFame);
        }

        // GET: HallOfFames/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallOfFame hallOfFame = db.HallOfFame.Find(id);
            if (hallOfFame == null)
            {
                return HttpNotFound();
            }
            return View(hallOfFame);
        }

        // POST: HallOfFames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hofID,yearID,votedBy,ballots,needed,votes,inducted,category,needed_note")] HallOfFame hallOfFame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hallOfFame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hallOfFame);
        }

        // GET: HallOfFames/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallOfFame hallOfFame = db.HallOfFame.Find(id);
            if (hallOfFame == null)
            {
                return HttpNotFound();
            }
            return View(hallOfFame);
        }

        // POST: HallOfFames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HallOfFame hallOfFame = db.HallOfFame.Find(id);
            db.HallOfFame.Remove(hallOfFame);
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
