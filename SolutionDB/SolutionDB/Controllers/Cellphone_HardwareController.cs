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
    public class Cellphone_HardwareController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Cellphone_Hardware
        public ActionResult Index()
        {
            var cellphone_Hardware = db.Cellphone_Hardware.Include(c => c.Cellphone_Battery);
            return View(cellphone_Hardware.ToList());
        }

        // GET: Cellphone_Hardware/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone_Hardware cellphone_Hardware = db.Cellphone_Hardware.Find(id);
            if (cellphone_Hardware == null)
            {
                return HttpNotFound();
            }
            return View(cellphone_Hardware);
        }

        // GET: Cellphone_Hardware/Create
        public ActionResult Create()
        {
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Battery, "Id", "Name");
            return View();
        }

        // POST: Cellphone_Hardware/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SubCategory_Id")] Cellphone_Hardware cellphone_Hardware)
        {
            if (ModelState.IsValid)
            {
                db.Cellphone_Hardware.Add(cellphone_Hardware);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Battery, "Id", "Name", cellphone_Hardware.SubCategory_Id);
            return View(cellphone_Hardware);
        }

        // GET: Cellphone_Hardware/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone_Hardware cellphone_Hardware = db.Cellphone_Hardware.Find(id);
            if (cellphone_Hardware == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Battery, "Id", "Name", cellphone_Hardware.SubCategory_Id);
            return View(cellphone_Hardware);
        }

        // POST: Cellphone_Hardware/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SubCategory_Id")] Cellphone_Hardware cellphone_Hardware)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cellphone_Hardware).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Battery, "Id", "Name", cellphone_Hardware.SubCategory_Id);
            return View(cellphone_Hardware);
        }

        // GET: Cellphone_Hardware/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone_Hardware cellphone_Hardware = db.Cellphone_Hardware.Find(id);
            if (cellphone_Hardware == null)
            {
                return HttpNotFound();
            }
            return View(cellphone_Hardware);
        }

        // POST: Cellphone_Hardware/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cellphone_Hardware cellphone_Hardware = db.Cellphone_Hardware.Find(id);
            db.Cellphone_Hardware.Remove(cellphone_Hardware);
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
