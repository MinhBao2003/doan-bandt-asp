using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_Nhom3.Models;


namespace DoAn_Nhom3.Controllers
{
    public class TrangChusController : Controller
    {
        DataBase db=new DataBase();
        // GET: TrangChus
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Trangchu()
        {
            return View(db.ProductCs.ToList());
        }
    }
}