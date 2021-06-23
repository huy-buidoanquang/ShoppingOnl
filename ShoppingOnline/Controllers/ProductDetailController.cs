using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace ShoppingOnline.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetails
        public ActionResult Index(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var product = db.SanPhams.Include(x => x.CTSanPhams).Where(x => x.SanPhamID == id).FirstOrDefault();
                var productDetail = db.CTSanPhams.SingleOrDefault(x => x.SanPhamID == id);
                var listSimilarProducts = new List<SanPham>();
                if (product.LoaiSanPhamID != null)
                {
                    listSimilarProducts = db.SanPhams.Where(x => x.LoaiSanPhamID == product.LoaiSanPhamID).Take(12).ToList();
                }
                if (product == null)
                {
                    return View("Error");
                }
                ViewData["product"] = product;
                ViewData["productDetail"] = productDetail;
                ViewData["listSimilarProducts"] = listSimilarProducts;
                return View();
            }
            
        }
    }
}