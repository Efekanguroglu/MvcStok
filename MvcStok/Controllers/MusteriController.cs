using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Musteriler()
        {
            var degerler = db.TblMusteriler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteriler m1)
        {
            db.TblMusteriler.Add(m1);
             db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var musteriler = db.TblMusteriler.Find(id);
            db.TblMusteriler.Remove(musteriler);
            db.SaveChanges();
            return RedirectToAction("Musteriler");
        }
    }
}