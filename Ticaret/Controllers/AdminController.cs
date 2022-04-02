using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticaret.Entity;
using Ticaret.Models;

namespace Ticaret.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataContext db = new DataContext();
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            StateModel model = new StateModel();
            model.BekleyenSiparisSayisi = db.Orders.Where(i => i.EnumOrderState == EnumOrderState.Bekleniyor).ToList().Count();
            model.TamamlananSiparisSayisi = db.Orders.Where(i => i.EnumOrderState == EnumOrderState.Tamamlandı).ToList().Count();
            model.PaketlenenSiparisSayisi = db.Orders.Where(i => i.EnumOrderState == EnumOrderState.Paketlendi).ToList().Count();
            model.KargolananSiparisSayisi = db.Orders.Where(i => i.EnumOrderState == EnumOrderState.Tamamlandı).ToList().Count();
            model.UrunSayisi = db.Products.Count();
            model.SiparisSayisi = db.Orders.Count();
            return View(model);
        }
    }
}