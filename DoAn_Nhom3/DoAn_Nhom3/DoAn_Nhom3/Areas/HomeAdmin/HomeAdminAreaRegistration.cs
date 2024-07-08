using System.Web.Mvc;

namespace DoAn_Nhom3.Areas.HomeAdmin
{
    public class HomeAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HomeAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HomeAdmin_default",
                "HomeAdmin/{controller}/{action}/{id}",
                new { action = "Index",Controller="HomeAdmin", id = UrlParameter.Optional }
            );
        }
    }
}