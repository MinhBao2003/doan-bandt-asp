using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DoAn_Nhom3.Models
{
    public class LoginModel
    {
        DataBase db = new DataBase();

        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool IsValid(LoginModel model)
        {
            try
            {
                if (Convert.ToBoolean(db.Admins.First(x => x.TaiKhoan == model.Username && x.MatKhau == model.Password).Id_Admin))
                {
                    SetAdminSession(db.Admins.First(x => x.TaiKhoan == model.Username && x.MatKhau == model.Password).Id_Admin);
                    return true;
                }
            }
            catch (Exception) { }
            try
            {
                if (Convert.ToBoolean(db.NhanViens.First(x => x.TaiKhoan == model.Username && x.MatKhau == model.Password).Id_NhanVien))
                {
                    SetNhanVienSession(db.NhanViens.First(x => x.TaiKhoan == model.Username && x.MatKhau == model.Password).Id_NhanVien);
                    return true;
                }
            }
            catch (Exception) { }
            try
            {
                if (Convert.ToBoolean(db.KhachHangs.First(x => x.TaiKhoan == model.Username && x.MatKhau == model.Password).Id_KhachHang))
                {
                    SetKhachHangSession(db.KhachHangs.First(x => x.TaiKhoan == model.Username && x.MatKhau == model.Password).Id_KhachHang);
                    return true;
                }
            }
            catch (Exception) { }
            return false;
        }
        public void SetAdminSession(int userID)
        {
            Admin user = db.Admins.SingleOrDefault(x => x.Id_Admin == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.Id_Admin);
            HttpContext.Current.Session.Add(Models.UserSession.PERMISSION, user.Id_Quyen);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.TaiKhoan);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.Email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.HoTenAD);
        }
        public void SetNhanVienSession(int userID)
        {
            NhanVien user = db.NhanViens.SingleOrDefault(x => x.Id_NhanVien == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.Id_NhanVien);
            HttpContext.Current.Session.Add(Models.UserSession.PERMISSION, user.Id_Quyen);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.TaiKhoan);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.Email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.HoTenNV);
        }
        public void SetKhachHangSession(int userID)
        {
            KhachHang user = db.KhachHangs.SingleOrDefault(x => x.Id_KhachHang == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.Id_KhachHang);
            HttpContext.Current.Session.Add(Models.UserSession.PERMISSION, user.Id_Quyen);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.TaiKhoan);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.Email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.HoTenKH);
        }
    }
}