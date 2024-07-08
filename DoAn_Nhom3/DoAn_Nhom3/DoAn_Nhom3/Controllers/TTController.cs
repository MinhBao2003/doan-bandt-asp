using DoAn_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_Nhom3.Controllers
{
    public class TTController : Controller
    {
        DataBase db = new DataBase();
        // GET: TT
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ThongTin()
        {
            return View(db.ThongTins.ToList());
        }
        public ActionResult BinhLuan()
        {
            return View();
        }
    }
}