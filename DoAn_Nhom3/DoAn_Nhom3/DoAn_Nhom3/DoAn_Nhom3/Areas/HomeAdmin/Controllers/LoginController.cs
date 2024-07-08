using DoAn_Nhom3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_Nhom3.Areas.HomeAdmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: HomeAdmin/Login
        User user;
        public ActionResult Index()
        {
            if (Session[UserSession.ISLOGIN] != null && (bool)Session[UserSession.ISLOGIN])
            {
                if ((int)Session[UserSession.PERMISSION] == 1)
                    return RedirectToAction("Index", "admins");
                if ((int)Session[UserSession.PERMISSION] == 2)
                    return RedirectToAction("Index", "nhanViens");
                if ((int)Session[UserSession.PERMISSION] == 3)
                    return RedirectToAction("Index", "khachHangs");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsValid(model))
                {
                    user = new User();
                    if (user.IsAdmin())
                        return RedirectToAction("Index", "admins");
                    if (user.IsTeacher())
                        return RedirectToAction("Index", "nhanViens");
                    if (user.IsStudent())
                        return RedirectToAction("Index", "khachHangs");
                }
                else
                    ViewBag.error = "Username or password incorrect";
            }
            else
                ViewBag.error = "Error, Please! try again";
            return View();
        }
        /*public ActionResult Index()
        {
            // Session["User"] = null;
            return View();
        }*/
        public ActionResult DangXuat()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}