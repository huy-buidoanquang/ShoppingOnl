using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingOnline.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Header()
        {
            var db = new ApplicationDbContext();
            var listProductsCategoryWomen = db.PhanLoaiSanPhams.Where(x => x.DanhMucSanPham.LaDoNu == true && (x.DanhMucSanPham.LaDoNam == false || x.DanhMucSanPham.LaDoNam == null)).ToList();
            ViewData["listProductsCategoryWomen"] = listProductsCategoryWomen;
            var listProductsCategoryMen = db.PhanLoaiSanPhams.Where(x => x.DanhMucSanPham.LaDoNam == true && (x.DanhMucSanPham.LaDoNu == false || x.DanhMucSanPham.LaDoNu == null)).ToList();
            ViewData["listProductsCategoryMen"] = listProductsCategoryMen;
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
    }
}