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
    public class ThongTinsController : Controller
    {
        private DataBase db = new DataBase();

        // GET: HomeAdmin/ThongTins
        public ActionResult Index()
        {
            return View(db.ThongTins.ToList());
        }

        // GET: HomeAdmin/ThongTins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTins.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            return View(thongTin);
        }

        // GET: HomeAdmin/ThongTins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeAdmin/ThongTins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "noidung,Ten,Hinh,Hinh2,Hinh3,NoiDung2")] ThongTin thongTin)
        {
            if (ModelState.IsValid)
            {
                db.ThongTins.Add(thongTin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongTin);
        }

        // GET: HomeAdmin/ThongTins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTins.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            return View(thongTin);
        }

        // POST: HomeAdmin/ThongTins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "noidung,Ten,Hinh,Hinh2,Hinh3,NoiDung2")] ThongTin thongTin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongTin);
        }

        // GET: HomeAdmin/ThongTins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTins.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            return View(thongTin);
        }

        // POST: HomeAdmin/ThongTins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThongTin thongTin = db.ThongTins.Find(id);
            db.ThongTins.Remove(thongTin);
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
