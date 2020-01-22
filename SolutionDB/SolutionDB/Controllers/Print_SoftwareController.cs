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
    public class Print_SoftwareController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Print_Software
        public ActionResult Index()
        {
            var print_Software = db.Print_Software.Include(p => p.Solution);
            return View(print_Software.ToList());
        }

        // GET: Print_Software/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Print_Software print_Software = db.Print_Software.Find(id);
            if (print_Software == null)
            {
                return HttpNotFound();
            }
            return View(print_Software);
        }

        // GET: Print_Software/Create
        public ActionResult Create()
        {
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name");
            return View();
        }

        // POST: Print_Software/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Solution_Id")] Print_Software print_Software)
        {
            if (ModelState.IsValid)
            {
                db.Print_Software.Add(print_Software);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", print_Software.Solution_Id);
            return View(print_Software);
        }

        // GET: Print_Software/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Print_Software print_Software = db.Print_Software.Find(id);
            if (print_Software == null)
            {
                return HttpNotFound();
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", print_Software.Solution_Id);
            return View(print_Software);
        }

        // POST: Print_Software/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Solution_Id")] Print_Software print_Software)
        {
            if (ModelState.IsValid)
            {
                db.Entry(print_Software).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", print_Software.Solution_Id);
            return View(print_Software);
        }

        // GET: Print_Software/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Print_Software print_Software = db.Print_Software.Find(id);
            if (print_Software == null)
            {
                return HttpNotFound();
            }
            return View(print_Software);
        }

        // POST: Print_Software/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Print_Software print_Software = db.Print_Software.Find(id);
            db.Print_Software.Remove(print_Software);
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
