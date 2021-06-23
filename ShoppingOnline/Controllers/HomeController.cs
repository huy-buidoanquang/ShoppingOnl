using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var listNewProducts = db.SanPhams.OrderByDescending(x => x.NgayTao).Take(12).ToList();
                ViewData["listNewProducts"] = listNewProducts;
                var listHotProducts = db.SanPhams.Where(x => x.Hot == true).Take(12).ToList();
                ViewData["listHotProducts"] = listHotProducts;
                return View();
            }
        } 
    }
}