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
    public class PCsController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: PCs
        public ActionResult Index()
        {
            var pCs = db.PCs.Include(p => p.O);
            return View(pCs.ToList());
        }

        // GET: PCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PC pC = db.PCs.Find(id);
            if (pC == null)
            {
                return HttpNotFound();
            }
            return View(pC);
        }

        // GET: PCs/Create
        public ActionResult Create()
        {
            ViewBag.SubCategory_Id = new SelectList(db.OS, "Id", "Name");
            return View();
        }

        // POST: PCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SubCategory_Id")] PC pC)
        {
            if (ModelState.IsValid)
            {
                db.PCs.Add(pC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategory_Id = new SelectList(db.OS, "Id", "Name", pC.SubCategory_Id);
            return View(pC);
        }

        // GET: PCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PC pC = db.PCs.Find(id);
            if (pC == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategory_Id = new SelectList(db.OS, "Id", "Name", pC.SubCategory_Id);
            return View(pC);
        }

        // POST: PCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SubCategory_Id")] PC pC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategory_Id = new SelectList(db.OS, "Id", "Name", pC.SubCategory_Id);
            return View(pC);
        }

        // GET: PCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PC pC = db.PCs.Find(id);
            if (pC == null)
            {
                return HttpNotFound();
            }
            return View(pC);
        }

        // POST: PCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PC pC = db.PCs.Find(id);
            db.PCs.Remove(pC);
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
