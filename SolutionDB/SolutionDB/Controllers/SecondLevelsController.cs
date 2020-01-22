using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolutionDB.Models;

namespace SolutionDB.Controllers
{
    public class SecondLevelsController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: SecondLevels
        public ActionResult Index()
        {
            var secondLevels = db.SecondLevels.Include(s => s.Incident);
            return View(secondLevels.ToList());
        }

        // GET: SecondLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecondLevel secondLevel = db.SecondLevels.Find(id);
            if (secondLevel == null)
            {
                return HttpNotFound();
            }
            return View(secondLevel);
        }

        // GET: SecondLevels/Create
        public ActionResult Create()
        {
            ViewBag.Ticket_Id = new SelectList(db.Incidents, "Id", "Descrition");
            return View();
        }

        // POST: SecondLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ticket_Id")] SecondLevel secondLevel)
        {
            if (ModelState.IsValid)
            {
                db.SecondLevels.Add(secondLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ticket_Id = new SelectList(db.Incidents, "Id", "Descrition", secondLevel.Ticket_Id);
            return View(secondLevel);
        }

        // GET: SecondLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecondLevel secondLevel = db.SecondLevels.Find(id);
            if (secondLevel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ticket_Id = new SelectList(db.Incidents, "Id", "Descrition", secondLevel.Ticket_Id);
            return View(secondLevel);
        }

        // POST: SecondLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ticket_Id")] SecondLevel secondLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secondLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ticket_Id = new SelectList(db.Incidents, "Id", "Descrition", secondLevel.Ticket_Id);
            return View(secondLevel);
        }

        // GET: SecondLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecondLevel secondLevel = db.SecondLevels.Find(id);
            if (secondLevel == null)
            {
                return HttpNotFound();
            }
            return View(secondLevel);
        }

        // POST: SecondLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecondLevel secondLevel = db.SecondLevels.Find(id);
            db.SecondLevels.Remove(secondLevel);
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
