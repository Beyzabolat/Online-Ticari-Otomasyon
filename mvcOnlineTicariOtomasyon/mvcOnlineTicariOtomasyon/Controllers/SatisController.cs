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
            q.SatisHareketis.Add(s);
            q.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetirme(int id)
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
            var dgr = q.SatisHareketis.Find(id);
            return View("SatisGetirme", dgr);
        }
        public ActionResult SatisGuncelle(SatisHareketi p)
        {
            var deger = q.SatisHareketis.Find(p.SatisID);
            deger.Cariid = p.Cariid;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.ToplamTutar = p.ToplamTutar;
            deger.Tarih = p.Tarih;
            deger.Urunid = p.Urunid;
            deger.Personelid = p.Personelid;
            q.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = q.SatisHareketis.Where(x => x.SatisID == id).ToList();

            //var dpt = q.Departmen.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();

            //ViewBag.d = dpt;
            return View(degerler);

        }
    }
}