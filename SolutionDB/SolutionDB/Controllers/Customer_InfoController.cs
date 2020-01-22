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
    public class Customer_InfoController : Controller
    {
        private SolutionDBEntities3 db = new SolutionDBEntities3();

        // GET: Customer_Info
        public ActionResult Index()
        {
            return View(db.Customer_Info.ToList());
        }

        // GET: Customer_Info/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Info customer_Info = db.Customer_Info.Find(id);
            if (customer_Info == null)
            {
                return HttpNotFound();
            }
            return View(customer_Info);
        }

        // GET: Customer_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Number,Mail,City,Street,zip")] Customer_Info customer_Info)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Info.Add(customer_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_Info);
        }

        // GET: Customer_Info/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Info customer_Info = db.Customer_Info.Find(id);
            if (customer_Info == null)
            {
                return HttpNotFound();
            }
            return View(customer_Info);
        }

        // POST: Customer_Info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Number,Mail,City,Street,zip")] Customer_Info customer_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_Info);
        }

        // GET: Customer_Info/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Info customer_Info = db.Customer_Info.Find(id);
            if (customer_Info == null)
            {
                return HttpNotFound();
            }
            return View(customer_Info);
        }

        // POST: Customer_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer_Info customer_Info = db.Customer_Info.Find(id);
            db.Customer_Info.Remove(customer_Info);
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
