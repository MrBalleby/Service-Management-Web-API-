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
    public class CellphonesController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Cellphones
        public ActionResult Index()
        {
            var cellphones = db.Cellphones.Include(c => c.Cellphone_Hardware).Include(c => c.Cellphone_Software);
            return View(cellphones.ToList());
        }

        // GET: Cellphones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone cellphone = db.Cellphones.Find(id);
            if (cellphone == null)
            {
                return HttpNotFound();
            }
            return View(cellphone);
        }

        // GET: Cellphones/Create
        public ActionResult Create()
        {
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Hardware, "Id", "Name");
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Software, "Id", "Name");
            return View();
        }

        // POST: Cellphones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SubCategory_Id")] Cellphone cellphone)
        {
            if (ModelState.IsValid)
            {
                db.Cellphones.Add(cellphone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Hardware, "Id", "Name", cellphone.SubCategory_Id);
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Software, "Id", "Name", cellphone.SubCategory_Id);
            return View(cellphone);
        }

        // GET: Cellphones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone cellphone = db.Cellphones.Find(id);
            if (cellphone == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Hardware, "Id", "Name", cellphone.SubCategory_Id);
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Software, "Id", "Name", cellphone.SubCategory_Id);
            return View(cellphone);
        }

        // POST: Cellphones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SubCategory_Id")] Cellphone cellphone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cellphone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Hardware, "Id", "Name", cellphone.SubCategory_Id);
            ViewBag.SubCategory_Id = new SelectList(db.Cellphone_Software, "Id", "Name", cellphone.SubCategory_Id);
            return View(cellphone);
        }

        // GET: Cellphones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cellphone cellphone = db.Cellphones.Find(id);
            if (cellphone == null)
            {
                return HttpNotFound();
            }
            return View(cellphone);
        }

        // POST: Cellphones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cellphone cellphone = db.Cellphones.Find(id);
            db.Cellphones.Remove(cellphone);
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
