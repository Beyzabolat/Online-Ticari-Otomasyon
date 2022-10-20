using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context q = new Context();
        public ActionResult Index()
        {
            var degerler = q.SatisHareketis.ToList();
            return View(degerler);
        }

        [HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger = (from x in q.Urunlers.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAdi,
                                              Value = x.UrunID.ToString()
                                          }).ToList();


            List<SelectListItem> deger1 = (from x in q.Caris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in q.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr = deger;
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View();

        }
        [HttpPost] //butona tıklandığında çalışacak
        public ActionResult YeniSatis(SatisHareketi s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            //s.Urunler = q.Urunlers.Find(s.Urunler.UrunID);
            //s.Personel = q.Personels.Find(s.Personel.PersonelID);
            //s.Cari = q.Caris.Find(s.Cari.CariID);
            q.SatisHareketis.Add(s);
            q.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}