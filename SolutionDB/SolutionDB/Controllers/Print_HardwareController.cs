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
    public class Print_HardwareController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Print_Hardware
        public ActionResult Index()
        {
            var print_Hardware = db.Print_Hardware.Include(p => p.Solution);
            return View(print_Hardware.ToList());
        }

        // GET: Print_Hardware/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Print_Hardware print_Hardware = db.Print_Hardware.Find(id);
            if (print_Hardware == null)
            {
                return HttpNotFound();
            }
            return View(print_Hardware);
        }

        // GET: Print_Hardware/Create
        public ActionResult Create()
        {
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name");
            return View();
        }

        // POST: Print_Hardware/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Solution_Id")] Print_Hardware print_Hardware)
        {
            if (ModelState.IsValid)
            {
                db.Print_Hardware.Add(print_Hardware);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", print_Hardware.Solution_Id);
            return View(print_Hardware);
        }

        // GET: Print_Hardware/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Print_Hardware print_Hardware = db.Print_Hardware.Find(id);
            if (print_Hardware == null)
            {
                return HttpNotFound();
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", print_Hardware.Solution_Id);
            return View(print_Hardware);
        }

        // POST: Print_Hardware/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Solution_Id")] Print_Hardware print_Hardware)
        {
            if (ModelState.IsValid)
            {
                db.Entry(print_Hardware).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", print_Hardware.Solution_Id);
            return View(print_Hardware);
        }

        // GET: Print_Hardware/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Print_Hardware print_Hardware = db.Print_Hardware.Find(id);
            if (print_Hardware == null)
            {
                return HttpNotFound();
            }
            return View(print_Hardware);
        }

        // POST: Print_Hardware/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Print_Hardware print_Hardware = db.Print_Hardware.Find(id);
            db.Print_Hardware.Remove(print_Hardware);
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
