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
    public class RegistryChangesController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: RegistryChanges
        public ActionResult Index()
        {
            var registryChanges = db.RegistryChanges.Include(r => r.Solution);
            return View(registryChanges.ToList());
        }

        // GET: RegistryChanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistryChange registryChange = db.RegistryChanges.Find(id);
            if (registryChange == null)
            {
                return HttpNotFound();
            }
            return View(registryChange);
        }

        // GET: RegistryChanges/Create
        public ActionResult Create()
        {
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name");
            return View();
        }

        // POST: RegistryChanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Solution_Id")] RegistryChange registryChange)
        {
            if (ModelState.IsValid)
            {
                db.RegistryChanges.Add(registryChange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", registryChange.Solution_Id);
            return View(registryChange);
        }

        // GET: RegistryChanges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistryChange registryChange = db.RegistryChanges.Find(id);
            if (registryChange == null)
            {
                return HttpNotFound();
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", registryChange.Solution_Id);
            return View(registryChange);
        }

        // POST: RegistryChanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Solution_Id")] RegistryChange registryChange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registryChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Solution_Id = new SelectList(db.Solutions, "Id", "Name", registryChange.Solution_Id);
            return View(registryChange);
        }

        // GET: RegistryChanges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistryChange registryChange = db.RegistryChanges.Find(id);
            if (registryChange == null)
            {
                return HttpNotFound();
            }
            return View(registryChange);
        }

        // POST: RegistryChanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistryChange registryChange = db.RegistryChanges.Find(id);
            db.RegistryChanges.Remove(registryChange);
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
