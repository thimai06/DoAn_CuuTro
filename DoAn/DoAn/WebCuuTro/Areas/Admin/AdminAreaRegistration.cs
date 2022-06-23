using System.Web.Mvc;

namespace WebCuuTro.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "ChiTietNguoiDung",
                url: "Admin/{controller}/{action}",
                defaults: new {controller = "Personal", action = "Details", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "ChinhSuaNguoiDung",
                url: "Admin/{controller}/{action}",
                defaults: new { controller = "Personal", action = "Edit", id = UrlParameter.Optional }
            );
            context.MapRoute(
                name: "XemChiTietDangKy",
                url: "Admin/{controller}/{action}",
                defaults: new { controller = "Registration", action = "Details", id = UrlParameter.Optional }
            );

            
            context.MapRoute(
                name: "ChinhSuaDanhMuc",
                url: "Admin/{controller}/{action}",
                defaults: new { controller = "Categorize", action = "Edit", id = UrlParameter.Optional }
            );
            
        }
    }
}