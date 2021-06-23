using ShoppingOnline.DAO;
using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingOnline.Controllers
{
    public class ListProductByCategoryController : Controller
    {
        // GET: ListProductByCategory
        public ActionResult Index(int? id, int page = 1, int pageSize = 4)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id.HasValue)
                {

                    var categoryName = db.PhanLoaiSanPhams.Where(x => x.PhanLoaiSanPhamID == id).Select(x => x.TenPhanLoaiSanPham).FirstOrDefault();
                    int totalRecord = 0;
                    var listProductsByCategory = ProductDAO.Instance.ListByCategoryId(id, ref totalRecord, page, pageSize);
                    ViewBag.Total = totalRecord;
                    ViewBag.Page = page;
                    int maxPage = 5;
                    int totalPage = 0;

                    totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
                    ViewBag.TotalPage = totalPage + 1;
                    ViewBag.MaxPage = maxPage;
                    ViewBag.First = 1;
                    ViewBag.Last = totalPage;
                    ViewBag.Next = page + 1;
                    ViewBag.Prev = page - 1;

                    ViewData["listProductsByCategory"] = listProductsByCategory;
                    ViewBag.categoryName = categoryName;
                    ViewBag.categoryID = id;
                }
                else
                {
                    var listProductsByCategory = db.SanPhams.OrderByDescending(x => x.SanPhamID).Take(12).ToList();
                    ViewData["listProductsByCategory"] = listProductsByCategory;
                    ViewBag.categoryName = "Sản phẩm";
                    ViewBag.categoryID = id;
                }
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult Search(int page = 1, int pageSize = 4)
        {
            using (var db = new ApplicationDbContext())
            {
                var keyword = Request.Form["searchString"];
                var id = Convert.ToInt32(Request.Form["id"]);
                var categoryName = db.PhanLoaiSanPhams.Where(x => x.PhanLoaiSanPhamID == id).Select(x => x.TenPhanLoaiSanPham).FirstOrDefault();
                var totalRecord = 0;
                var listProductsByCategory = ProductDAO.Instance.Search(id, keyword, ref totalRecord, page, pageSize);

                ViewBag.Total = totalRecord;
                ViewBag.Page = page;
                ViewBag.Keyword = keyword;
                int maxPage = 5;
                int totalPage = 0;

                totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
                ViewBag.TotalPage = totalPage + 1;
                ViewBag.MaxPage = maxPage;
                ViewBag.First = 1;
                ViewBag.Last = totalPage;
                ViewBag.Next = page + 1;
                ViewBag.Prev = page - 1;
                ViewData["listProductsByCategory"] = listProductsByCategory;
                ViewBag.categoryName = categoryName;
                ViewBag.categoryID = id;
                return View("Index");
            }
        }
    }
}