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
    public class Cellphone_SoftwareController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Cellphone_Software
        public ActionResult Index()
        {
            var cellphone_Software = db.Cellphone_Software.Include(c => c.No_Connection);
            return View(cellphone_Software.ToList());
        }

        // GET: Cellphone_Software/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone_Software cellphone_Software = db.Cellphone_Software.Find(id);
            if (cellphone_Software == null)
            {
                return HttpNotFound();
            }
            return View(cellphone_Software);
        }

        // GET: Cellphone_Software/Create
        public ActionResult Create()
        {
            ViewBag.SubCategory_Id = new SelectList(db.No_Connection, "Id", "Name");
            return View();
        }

        // POST: Cellphone_Software/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SubCategory_Id")] Cellphone_Software cellphone_Software)
        {
            if (ModelState.IsValid)
            {
                db.Cellphone_Software.Add(cellphone_Software);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategory_Id = new SelectList(db.No_Connection, "Id", "Name", cellphone_Software.SubCategory_Id);
            return View(cellphone_Software);
        }

        // GET: Cellphone_Software/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone_Software cellphone_Software = db.Cellphone_Software.Find(id);
            if (cellphone_Software == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategory_Id = new SelectList(db.No_Connection, "Id", "Name", cellphone_Software.SubCategory_Id);
            return View(cellphone_Software);
        }

        // POST: Cellphone_Software/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SubCategory_Id")] Cellphone_Software cellphone_Software)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cellphone_Software).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategory_Id = new SelectList(db.No_Connection, "Id", "Name", cellphone_Software.SubCategory_Id);
            return View(cellphone_Software);
        }

        // GET: Cellphone_Software/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone_Software cellphone_Software = db.Cellphone_Software.Find(id);
            if (cellphone_Software == null)
            {
                return HttpNotFound();
            }
            return View(cellphone_Software);
        }

        // POST: Cellphone_Software/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cellphone_Software cellphone_Software = db.Cellphone_Software.Find(id);
            db.Cellphone_Software.Remove(cellphone_Software);
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
