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
    public class No_ConnectionController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: No_Connection
        public ActionResult Index()
        {
            var no_Connection = db.No_Connection.Include(n => n.Solution);
            return View(no_Connection.ToList());
        }

        // GET: No_Connection/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            No_Connection no_Connection = db.No_Connection.Find(id);
            if (no_Connection == null)
            {
                return HttpNotFound();
            }
            return View(no_Connection);
        }

        // GET: No_Connection/Create
        public ActionResult Create()
        {
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name");
            return View();
        }

        // POST: No_Connection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Solution_Id")] No_Connection no_Connection)
        {
            if (ModelState.IsValid)
            {
                db.No_Connection.Add(no_Connection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", no_Connection.Solution_Id);
            return View(no_Connection);
        }

        // GET: No_Connection/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            No_Connection no_Connection = db.No_Connection.Find(id);
            if (no_Connection == null)
            {
                return HttpNotFound();
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", no_Connection.Solution_Id);
            return View(no_Connection);
        }

        // POST: No_Connection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Solution_Id")] No_Connection no_Connection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(no_Connection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", no_Connection.Solution_Id);
            return View(no_Connection);
        }

        // GET: No_Connection/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            No_Connection no_Connection = db.No_Connection.Find(id);
            if (no_Connection == null)
            {
                return HttpNotFound();
            }
            return View(no_Connection);
        }

        // POST: No_Connection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            No_Connection no_Connection = db.No_Connection.Find(id);
            db.No_Connection.Remove(no_Connection);
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
