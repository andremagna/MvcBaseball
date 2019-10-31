using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace BaseballApp.Controllers
{
    public class AllstarFullsController : Controller
    {
        private BaseballDataEntities db = new BaseballDataEntities();

        // GET: AllstarFulls
        public ActionResult Index()
        {
            return View(db.AllstarFull.ToList());
        }

        // GET: AllstarFulls/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllstarFull allstarFull = db.AllstarFull.Find(id);
            if (allstarFull == null)
            {
                return HttpNotFound();
            }
            return View(allstarFull);
        }

        // GET: AllstarFulls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllstarFulls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "playerID,yearID,gameNum,gameID,teamID,lgID,GP,startingPos")] AllstarFull allstarFull)
        {
            if (ModelState.IsValid)
            {
                db.AllstarFull.Add(allstarFull);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allstarFull);
        }

        // GET: AllstarFulls/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllstarFull allstarFull = db.AllstarFull.Find(id);
            if (allstarFull == null)
            {
                return HttpNotFound();
            }
            return View(allstarFull);
        }

        // POST: AllstarFulls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "playerID,yearID,gameNum,gameID,teamID,lgID,GP,startingPos")] AllstarFull allstarFull)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allstarFull).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allstarFull);
        }

        // GET: AllstarFulls/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllstarFull allstarFull = db.AllstarFull.Find(id);
            if (allstarFull == null)
            {
                return HttpNotFound();
            }
            return View(allstarFull);
        }

        // POST: AllstarFulls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AllstarFull allstarFull = db.AllstarFull.Find(id);
            db.AllstarFull.Remove(allstarFull);
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
