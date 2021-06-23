using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoppingOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ChiTietSanPham",
                url: "chi-tiet-san-pham/{id}",
                defaults: new { controller = "ProductDetail", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "DanhSachSanPhamTheoDanhMuc",
               url: "danh-sach-san-pham/{id}",
               defaults: new { controller = "ListProductByCategory", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
