using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAn_Nhom3.Models;

namespace DoAn_Nhom3.Areas.HomeAdmin.Controllers
{
    public class ProductCsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: HomeAdmin/ProductCs
        public ActionResult Index()
        {
            return View(db.ProductCs.ToList());
        }

        // GET: HomeAdmin/ProductCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductC productC = db.ProductCs.Find(id);
            if (productC == null)
            {
                return HttpNotFound();
            }
            return View(productC);
        }

        // GET: HomeAdmin/ProductCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeAdmin/ProductCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Photo")] ProductC productC)
        {
            if (ModelState.IsValid)
            {
                db.ProductCs.Add(productC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productC);
        }

        // GET: HomeAdmin/ProductCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductC productC = db.ProductCs.Find(id);
            if (productC == null)
            {
                return HttpNotFound();
            }
            return View(productC);
        }

        // POST: HomeAdmin/ProductCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Photo")] ProductC productC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productC);
        }

        // GET: HomeAdmin/ProductCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductC productC = db.ProductCs.Find(id);
            if (productC == null)
            {
                return HttpNotFound();
            }
            return View(productC);
        }

        // POST: HomeAdmin/ProductCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductC productC = db.ProductCs.Find(id);
            db.ProductCs.Remove(productC);
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
