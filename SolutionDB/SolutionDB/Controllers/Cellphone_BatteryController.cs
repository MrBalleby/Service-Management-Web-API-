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
    public class Cellphone_BatteryController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Cellphone_Battery
        public ActionResult Index()
        {
            var cellphone_Battery = db.Cellphone_Battery.Include(c => c.Solution);
            return View(cellphone_Battery.ToList());
        }

        // GET: Cellphone_Battery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone_Battery cellphone_Battery = db.Cellphone_Battery.Find(id);
            if (cellphone_Battery == null)
            {
                return HttpNotFound();
            }
            return View(cellphone_Battery);
        }

        // GET: Cellphone_Battery/Create
        public ActionResult Create()
        {
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name");
            return View();
        }

        // POST: Cellphone_Battery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Solution_Id")] Cellphone_Battery cellphone_Battery)
        {
            if (ModelState.IsValid)
            {
                db.Cellphone_Battery.Add(cellphone_Battery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", cellphone_Battery.Solution_Id);
            return View(cellphone_Battery);
        }

        // GET: Cellphone_Battery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone_Battery cellphone_Battery = db.Cellphone_Battery.Find(id);
            if (cellphone_Battery == null)
            {
                return HttpNotFound();
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", cellphone_Battery.Solution_Id);
            return View(cellphone_Battery);
        }

        // POST: Cellphone_Battery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Solution_Id")] Cellphone_Battery cellphone_Battery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cellphone_Battery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", cellphone_Battery.Solution_Id);
            return View(cellphone_Battery);
        }

        // GET: Cellphone_Battery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone_Battery cellphone_Battery = db.Cellphone_Battery.Find(id);
            if (cellphone_Battery == null)
            {
                return HttpNotFound();
            }
            return View(cellphone_Battery);
        }

        // POST: Cellphone_Battery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cellphone_Battery cellphone_Battery = db.Cellphone_Battery.Find(id);
            db.Cellphone_Battery.Remove(cellphone_Battery);
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
