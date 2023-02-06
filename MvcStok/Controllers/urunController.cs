using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class urunController : Controller
    {
        // GET: urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Urunler()
        {
            var degerler = db.Tblurunler.ToList();
            return View(degerler);
        }
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TblKategoriler
                                             select new SelectListItem
                                             {
                                                 Text = i.KatergoriAD,
                                                 Value = i.KategoriID.ToString(),

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Tblurunler u1)
        {
            var ktg = db.TblKategoriler.Where(i => i.KategoriID == u1.TblKategoriler.KategoriID).FirstOrDefault();
            u1.TblKategoriler = ktg;
            db.Tblurunler.Add(u1);
            db.SaveChanges();
            return RedirectToAction("Urunler");
        }
        public ActionResult Sil(int id)
        {
            var urunler = db.Tblurunler.Find(id);
            db.Tblurunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("urunler");
        }
    }
}