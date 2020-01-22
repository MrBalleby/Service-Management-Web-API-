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
    public class OController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: O
        public ActionResult Index()
        {
            var oS = db.OS.Include(o => o.RegistryChange);
            return View(oS.ToList());
        }

        // GET: O/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            O o = db.OS.Find(id);
            if (o == null)
            {
                return HttpNotFound();
            }
            return View(o);
        }

        // GET: O/Create
        public ActionResult Create()
        {
            ViewBag.SubCategory_Id = new SelectList(db.RegistryChanges, "Id", "Name");
            return View();
        }

        // POST: O/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SubCategory_Id")] O o)
        {
            if (ModelState.IsValid)
            {
                db.OS.Add(o);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategory_Id = new SelectList(db.RegistryChanges, "Id", "Name", o.SubCategory_Id);
            return View(o);
        }

        // GET: O/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            O o = db.OS.Find(id);
            if (o == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategory_Id = new SelectList(db.RegistryChanges, "Id", "Name", o.SubCategory_Id);
            return View(o);
        }

        // POST: O/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SubCategory_Id")] O o)
        {
            if (ModelState.IsValid)
            {
                db.Entry(o).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategory_Id = new SelectList(db.RegistryChanges, "Id", "Name", o.SubCategory_Id);
            return View(o);
        }

        // GET: O/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            O o = db.OS.Find(id);
            if (o == null)
            {
                return HttpNotFound();
            }
            return View(o);
        }

        // POST: O/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            O o = db.OS.Find(id);
            db.OS.Remove(o);
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
