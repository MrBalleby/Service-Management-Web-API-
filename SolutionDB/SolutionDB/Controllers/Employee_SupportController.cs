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
    public class Employee_SupportController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Employee_Support
        public ActionResult Index()
        {
            var employee_Support = db.Employee_Support.Include(e => e.Employee);
            return View(employee_Support.ToList());
        }

        // GET: Employee_Support/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Support employee_Support = db.Employee_Support.Find(id);
            if (employee_Support == null)
            {
                return HttpNotFound();
            }
            return View(employee_Support);
        }

        // GET: Employee_Support/Create
        public ActionResult Create()
        {
            ViewBag.Name_Id = new SelectList(db.Employees, "Id", "Name");
            return View();
        }

        // POST: Employee_Support/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name_Id,SupportLevel")] Employee_Support employee_Support)
        {
            if (ModelState.IsValid)
            {
                db.Employee_Support.Add(employee_Support);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Name_Id = new SelectList(db.Employees, "Id", "Name", employee_Support.Name_Id);
            return View(employee_Support);
        }

        // GET: Employee_Support/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Support employee_Support = db.Employee_Support.Find(id);
            if (employee_Support == null)
            {
                return HttpNotFound();
            }
            ViewBag.Name_Id = new SelectList(db.Employees, "Id", "Name", employee_Support.Name_Id);
            return View(employee_Support);
        }

        // POST: Employee_Support/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name_Id,SupportLevel")] Employee_Support employee_Support)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_Support).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Name_Id = new SelectList(db.Employees, "Id", "Name", employee_Support.Name_Id);
            return View(employee_Support);
        }

        // GET: Employee_Support/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Support employee_Support = db.Employee_Support.Find(id);
            if (employee_Support == null)
            {
                return HttpNotFound();
            }
            return View(employee_Support);
        }

        // POST: Employee_Support/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_Support employee_Support = db.Employee_Support.Find(id);
            db.Employee_Support.Remove(employee_Support);
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
