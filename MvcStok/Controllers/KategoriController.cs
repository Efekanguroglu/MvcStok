using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult KategoriListesi()
        {
            var degerler = db.TblKategoriler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TblKategoriler p1)
        {
            db.TblKategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("kategoriListesi");
        }
        public ActionResult KategoriGuncelle(int id)
        {
            var ktgr = db.TblKategoriler.Find(id);
            
            return View("KategoriGuncelle",ktgr);
        }

        public ActionResult Guncelle(TblKategoriler p1)
        {
            var ktg = db.TblKategoriler.Find(p1.KategoriID);
            ktg.KatergoriAD = p1.KatergoriAD;
            db.SaveChanges();
            return RedirectToAction("KategoriListesi");
        }
    }
   
}