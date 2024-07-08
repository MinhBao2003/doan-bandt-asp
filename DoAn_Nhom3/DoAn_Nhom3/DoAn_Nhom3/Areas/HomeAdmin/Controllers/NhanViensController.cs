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
    public class NhanViensController : Controller
    {
        private DataBase db = new DataBase();

        // GET: HomeAdmin/NhanViens
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.Quyen);
            return View(nhanViens.ToList());
        }

        // GET: HomeAdmin/NhanViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: HomeAdmin/NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten");
            return View();
        }

        // POST: HomeAdmin/NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_NhanVien,HoTenNV,TaiKhoan,MatKhau,Id_Quyen,Email")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten", nhanVien.Id_Quyen);
            return View(nhanVien);
        }

        // GET: HomeAdmin/NhanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten", nhanVien.Id_Quyen);
            return View(nhanVien);
        }

        // POST: HomeAdmin/NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_NhanVien,HoTenNV,TaiKhoan,MatKhau,Id_Quyen,Email")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten", nhanVien.Id_Quyen);
            return View(nhanVien);
        }

        // GET: HomeAdmin/NhanViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: HomeAdmin/NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
