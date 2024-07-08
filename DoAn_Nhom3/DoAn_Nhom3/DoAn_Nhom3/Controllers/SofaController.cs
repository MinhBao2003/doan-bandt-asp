using DoAn_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_Nhom3.Controllers
{
    public class SofaController : Controller
    {
        DataBase db = new DataBase();
        // GET: Sofa
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult sofa2()
        {
            string query = "SELECT * FROM ChiTietHang WHERE id = 2";
            List<ChiTietHang> data = db.ChiTietHangs.SqlQuery(query).ToList();
            return View(data);
        }
        public ActionResult sofa1()
        {
            string query = "SELECT * FROM ChiTietHang WHERE id = 1";
            List<ChiTietHang> data = db.ChiTietHangs.SqlQuery(query).ToList();
            return View(data);
        }
        public ActionResult sofa()
        {
            return View();
        }
        public ActionResult sofa3()
        {
            string query = "SELECT * FROM ChiTietHang WHERE id = 3";
            List<ChiTietHang> data = db.ChiTietHangs.SqlQuery(query).ToList();
            return View(data);
        }
        public ActionResult sofa4()
        {
            string query = "SELECT * FROM ChiTietHang WHERE id = 4";
            List<ChiTietHang> data = db.ChiTietHangs.SqlQuery(query).ToList();
            return View(data);
        }
    }
}