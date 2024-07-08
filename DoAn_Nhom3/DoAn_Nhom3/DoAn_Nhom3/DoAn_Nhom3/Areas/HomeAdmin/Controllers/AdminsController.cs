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
    public class AdminsController : Controller
    {
        private DataBase db = new DataBase();
        //Http get HomeAdmin/Admins/DangNhapAdmin
        public ActionResult DangNhapAdmin()
        {
            return View();
        }
        //Http Post HomeAdmin/Admins/DangNhapAdmin
        [HttpPost]
        public ActionResult DangNhapAdmin(Admin admin)
        {
            var taikhoang = admin.TaiKhoan;
            var matkhau = admin.MatKhau;
            var userCheck = db.Admins.SingleOrDefault(x => x.TaiKhoan.Equals(taikhoang) && x.MatKhau.Equals(matkhau));
            if (userCheck != null)
            {
                Session["User"] = userCheck;
                return RedirectToAction("Index", "Admins");
            }
            else
            {
                ViewBag.LoginFail = "Đăng Nhập Thất Bại,Vui Lòng Kiểm Tra Lại!";
                return View("DangNhapAdmin");
            }
            return View();
        }

        //Http Post HomeAdmin/Admins/DangXuatAdmin
        public ActionResult DangXuatAdmin()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "HomeAdmin");
        }
        // GET: HomeAdmin/Admins
        public ActionResult Index()
        {
            var admins = db.Admins.Include(a => a.Quyen);
            return View(admins.ToList());
        }
        
        // GET: HomeAdmin/Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: HomeAdmin/Admins/Create
        public ActionResult Create()
        {
            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten");
            return View();
        }

        // POST: HomeAdmin/Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Admin,HoTenAD,TaiKhoan,MatKhau,Id_Quyen,Email")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten", admin.Id_Quyen);
            return View(admin);
        }

        // GET: HomeAdmin/Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten", admin.Id_Quyen);
            return View(admin);
        }

        // POST: HomeAdmin/Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Admin,HoTenAD,TaiKhoan,MatKhau,Id_Quyen,Email")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten", admin.Id_Quyen);
            return View(admin);
        }

        // GET: HomeAdmin/Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: HomeAdmin/Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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
