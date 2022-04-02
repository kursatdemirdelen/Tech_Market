using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticaret.Entity;

namespace Ticaret.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public PartialViewResult _FeaturedProductList()
        {
            return PartialView(db.Products.Where(i => i.IsFeatured).Take(4).ToList());
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }

        public PartialViewResult Slider()
        {
            return PartialView(db.Products.Where(i => i.IsFeatured).Take(4).ToList());
        }
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult ProductDetails(int id)
        {
            return View(db.Products.Where(i=>i.Id==id).FirstOrDefault());
        }

        public ActionResult Product()
        {
            return View(db.Products.ToList());
        }
        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(i=>i.CategoryId==id).ToList());
        }
    }
}