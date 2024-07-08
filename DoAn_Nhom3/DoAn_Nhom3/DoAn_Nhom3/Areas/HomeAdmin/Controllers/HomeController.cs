using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_Nhom3.Areas.HomeAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeAdmin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}