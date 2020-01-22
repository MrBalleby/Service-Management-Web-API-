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
    public class PrintsController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Prints
        public ActionResult Index()
        {
            var prints = db.Prints.Include(p => p.Print_Hardware).Include(p => p.Print_Software);
            return View(prints.ToList());
        }

        // GET: Prints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Print print = db.Prints.Find(id);
            if (print == null)
            {
                return HttpNotFound();
            }
            return View(print);
        }

        // GET: Prints/Create
        public ActionResult Create()
        {
            ViewBag.SubCategory_Id = new SelectList(db.Print_Hardware, "Id", "Name");
            ViewBag.SubCategory_Id = new SelectList(db.Print_Software, "Id", "Name");
            return View();
        }

        // POST: Prints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SubCategory_Id")] Print print)
        {
            if (ModelState.IsValid)
            {
                db.Prints.Add(print);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategory_Id = new SelectList(db.Print_Hardware, "Id", "Name", print.SubCategory_Id);
            ViewBag.SubCategory_Id = new SelectList(db.Print_Software, "Id", "Name", print.SubCategory_Id);
            return View(print);
        }

        // GET: Prints/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Print print = db.Prints.Find(id);
            if (print == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategory_Id = new SelectList(db.Print_Hardware, "Id", "Name", print.SubCategory_Id);
            ViewBag.SubCategory_Id = new SelectList(db.Print_Software, "Id", "Name", print.SubCategory_Id);
            return View(print);
        }

        // POST: Prints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SubCategory_Id")] Print print)
        {
            if (ModelState.IsValid)
            {
                db.Entry(print).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategory_Id = new SelectList(db.Print_Hardware, "Id", "Name", print.SubCategory_Id);
            ViewBag.SubCategory_Id = new SelectList(db.Print_Software, "Id", "Name", print.SubCategory_Id);
            return View(print);
        }

        // GET: Prints/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Print print = db.Prints.Find(id);
            if (print == null)
            {
                return HttpNotFound();
            }
            return View(print);
        }

        // POST: Prints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Print print = db.Prints.Find(id);
            db.Prints.Remove(print);
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
