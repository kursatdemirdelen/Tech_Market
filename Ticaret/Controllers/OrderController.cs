using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticaret.Entity;
using Ticaret.Models;

namespace Ticaret.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        [Authorize(Roles = "admin")]
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrder()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                EnumOrderState = i.EnumOrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName = i.UserName,
                OrderDate = i.OrderDate,
                EnumOrderState = i.EnumOrderState,
                AdresBasligi = i.AdresBasligi,
                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    Image = x.Product.image,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()
            }).FirstOrDefault();
            return View(model);
        }
        public ActionResult UpdateOrderState(int OrderId, EnumOrderState EnumOrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order != null)
            {
                order.EnumOrderState = EnumOrderState;
                db.SaveChanges();
                TempData["mesaj"] = "bilgileriniz kaydedildi";

                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
        public ActionResult BekleyenSiparisler()
        {
            var orders = db.Orders.Where(i => i.EnumOrderState == EnumOrderState.Bekleniyor).ToList();
            return View(orders);
        }
        public ActionResult KargolananSiparisler()
        {
            var orders = db.Orders.Where(i => i.EnumOrderState == EnumOrderState.Kargolandı).ToList();
            return View(orders);
        }
        public ActionResult TamamlananSiparisler()
        {
            var orders = db.Orders.Where(i => i.EnumOrderState == EnumOrderState.Tamamlandı).ToList();
            return View(orders);
        }
        public ActionResult PaketlenenSiparisler()
        {
            var orders = db.Orders.Where(i => i.EnumOrderState == EnumOrderState.Paketlendi).ToList();
            return View(orders);
        }
    }
}