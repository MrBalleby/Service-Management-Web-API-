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
    public class IncidentsController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Incidents
        public ActionResult Index()
        {
            var incidents = db.Incidents.Include(i => i.Category).Include(i => i.Customer).Include(i => i.Solution).Include(i => i.Status).Include(i => i.Urgency);
            return View(incidents.ToList());
        }

        // GET: Incidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // GET: Incidents/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Caller_Id = new SelectList(db.Customers, "Id", "Name");
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name");
            ViewBag.Status_Id = new SelectList(db.Status, "Id", "State");
            ViewBag.Urgency_Id = new SelectList(db.Urgencies, "Id", "UrgencyState");
            return View();
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Caller_Id,Descrition,Category_Id,Opened,Urgency_Id,Status_Id,Solution_Id")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Incidents.Add(incident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name", incident.Category_Id);
            ViewBag.Caller_Id = new SelectList(db.Customers, "Id", "Name", incident.Caller_Id);
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", incident.Solution_Id);
            ViewBag.Status_Id = new SelectList(db.Status, "Id", "State", incident.Status_Id);
            ViewBag.Urgency_Id = new SelectList(db.Urgencies, "Id", "UrgencyState", incident.Urgency_Id);
            return View(incident);
        }

        // GET: Incidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name", incident.Category_Id);
            ViewBag.Caller_Id = new SelectList(db.Customers, "Id", "Name", incident.Caller_Id);
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", incident.Solution_Id);
            ViewBag.Status_Id = new SelectList(db.Status, "Id", "State", incident.Status_Id);
            ViewBag.Urgency_Id = new SelectList(db.Urgencies, "Id", "UrgencyState", incident.Urgency_Id);
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Caller_Id,Descrition,Category_Id,Opened,Urgency_Id,Status_Id,Solution_Id")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.Categories, "Id", "Name", incident.Category_Id);
            ViewBag.Caller_Id = new SelectList(db.Customers, "Id", "Name", incident.Caller_Id);
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", incident.Solution_Id);
            ViewBag.Status_Id = new SelectList(db.Status, "Id", "State", incident.Status_Id);
            ViewBag.Urgency_Id = new SelectList(db.Urgencies, "Id", "UrgencyState", incident.Urgency_Id);
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Incident incident = db.Incidents.Find(id);
            if (incident == null)
            {
                return HttpNotFound();
            }
            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Incident incident = db.Incidents.Find(id);
            db.Incidents.Remove(incident);
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
