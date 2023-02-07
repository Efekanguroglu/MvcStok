using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
       
        public ActionResult Musteriler(  int sayfa=1)
        {
            
            //var degerler = db.TblMusteriler.ToList();
            var degerler = db.TblMusteriler.ToList().ToPagedList(sayfa,3);
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
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            else
            {

                db.TblMusteriler.Add(m1);
                db.SaveChanges();
                return View();
            }
        }
        public ActionResult Sil(int id)
        {
            var musteriler = db.TblMusteriler.Find(id);
            db.TblMusteriler.Remove(musteriler);
            db.SaveChanges();
            return RedirectToAction("Musteriler");
        }
        public ActionResult MusteriGuncelle(int id)
        {
            var mstr = db.TblMusteriler.Find(id);

            return View("MusteriGuncelle", mstr);
        }
        public ActionResult Guncelle(TblMusteriler m1)
        {
            var mstrr = db.TblMusteriler.Find(m1.MusteriID);
            mstrr.MusteriAD = m1.MusteriAD;
            mstrr.MusteriSoyad = m1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Musteriler");
        }
    }
}