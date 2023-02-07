using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class urunController : Controller
    {
        // GET: urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Urunler(int sayfa=1)
        {
            //var degerler = db.Tblurunler.ToList();
            var degerler = db.Tblurunler.ToList().ToPagedList(sayfa,3);
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
        public ActionResult UrunGuncelle(int id)
        {
            var urun = db.Tblurunler.Find(id);
            List<SelectListItem> degerler = (from i in db.TblKategoriler
                                             select new SelectListItem
                                             {
                                                 Text = i.KatergoriAD,
                                                 Value = i.KategoriID.ToString(),

                                             }).ToList();
            ViewBag.dgr = degerler;
            return  View("UrunGuncelle",urun);
            
        }
        public ActionResult Guncelle(Tblurunler u1)
        {
            var uruns = db.Tblurunler.Find(u1.UrunID);
            uruns.UrunAdı = u1.UrunAdı;
            uruns.Marka = u1.Marka;
            //kategori farklı olacak 
            //uruns.UrunKategori = u1.UrunKategori;
            var ktgr = db.TblKategoriler.Where(x => x.KategoriID == u1.TblKategoriler.KategoriID).FirstOrDefault();
            u1.UrunKategori = ktgr.KategoriID;
            uruns.Fiyat = u1.Fiyat;
            uruns.Stok = u1.Stok;
            db.SaveChanges();
            return RedirectToAction("Urunler");

        }

    }
}