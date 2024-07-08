using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAn_Nhom3.Models;

namespace DoAn_Nhom3.Controllers
{
    public class KhachHangzController : Controller
    {
        private DataBase db = new DataBase();

        // GET: KhachHangz
        public ActionResult Index()
        {
            var khachHangs = db.KhachHangs.Include(k => k.Quyen);
            return View(khachHangs.ToList());
        }

        // GET: KhachHangz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHangz/Create
        public ActionResult Create()
        {
            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten");
            return View();
        }

        // POST: KhachHangz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_KhachHang,HoTenKH,TaiKhoan,MatKhau,Id_Quyen,Email")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("","");
            }

            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten", khachHang.Id_Quyen);
            return View(khachHang);
        }

        // GET: KhachHangz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten", khachHang.Id_Quyen);
            return View(khachHang);
        }

        // POST: KhachHangz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_KhachHang,HoTenKH,TaiKhoan,MatKhau,Id_Quyen,Email")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Quyen = new SelectList(db.Quyens, "Id_Quyen", "Quyen_Ten", khachHang.Id_Quyen);
            return View(khachHang);
        }

        // GET: KhachHangz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
        //Http get /KhachHangz/DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        //Http Post /KhachHangz/DangNhap
        [HttpPost]
        public ActionResult DangNhap(KhachHang khachHang)
        {
            var taikhoang = khachHang.TaiKhoan;
            var matkhau = khachHang.MatKhau;
            var userCheck = db.KhachHangs.SingleOrDefault(x => x.TaiKhoan.Equals(taikhoang) && x.MatKhau.Equals(matkhau));
            if (userCheck != null)
            {
                Session["User"] = userCheck;
                return RedirectToAction("Trangchu", "Trangchus");
            }
            else
            {
                ViewBag.LoginFail = "Đăng Nhập Thất Bại,Vui Lòng Kiểm Tra Lại!";
                return View("DangNhap");
            }
            return View();
        }

        //Http Post /KhachHangz/DangXuat
        public ActionResult DangXuat()
        {
            Session["User"] = null;
            return RedirectToAction("Trangchu", "Trangchus");
        }
    }
}
