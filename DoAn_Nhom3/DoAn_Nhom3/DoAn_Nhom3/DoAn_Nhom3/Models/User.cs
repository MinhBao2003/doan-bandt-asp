﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_Nhom3.Models
{
    public class User
    {
        public bool ISLOGIN { get; set; } = false;
        public int ID { get; set; }
        public int PERMISSION { get; set; }
        public string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string NAME { get; set; }

        public User()
        {
            try
            {
                ISLOGIN = (bool)HttpContext.Current.Session[UserSession.ISLOGIN];
                ID = (int)HttpContext.Current.Session[UserSession.ID];
                PERMISSION = (int)HttpContext.Current.Session[UserSession.PERMISSION];
                USERNAME = (string)HttpContext.Current.Session[UserSession.USERNAME];
                EMAIL = (string)HttpContext.Current.Session[UserSession.EMAIL];
                NAME = (string)HttpContext.Current.Session[UserSession.NAME];
            }
            catch (Exception) { }
        }
        public bool IsLogin()
        {
            try
            {
                if (ISLOGIN)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Reset()
        {
            HttpContext.Current.Session.Clear();
        }
        public bool IsAdmin()
        {
            try
            {
                if (ISLOGIN && PERMISSION == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsTeacher()
        {
            try
            {
                if (ISLOGIN && PERMISSION == 2)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsStudent()
        {
            try
            {
                if (ISLOGIN && PERMISSION == 3)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}