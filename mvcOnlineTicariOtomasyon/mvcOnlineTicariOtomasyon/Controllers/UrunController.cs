using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context q = new Context();
        public ActionResult Index()
        {
            var urunler = q.Urunlers.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }


        [HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        public ActionResult UrunEkleme()
        {
            List<SelectListItem> deger1 = (from x in q.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();

        }
        [HttpPost] //butona tıklandığında çalışacak
        public ActionResult UrunEkleme(Urunler m)
        {
            q.Urunlers.Add(m);
            q.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSilme(int id)
        {
            var urunn = q.Urunlers.Find(id);
            urunn.Durum = false;
            q.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetirme(int id)
        {
            List<SelectListItem> deger1 = (from x in q.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var uruun = q.Urunlers.Find(id);
            return View("UrunGetirme", uruun);
        }
        public ActionResult UrunGuncelle(Urunler p)
        {
            var urunnnn = q.Urunlers.Find(p.UrunID);
            urunnnn.AlisFiyati = p.AlisFiyati;
            urunnnn.Durum = p.Durum;
            urunnnn.Kategoriid = p.Kategoriid;
            urunnnn.Marka = p.Marka;
            urunnnn.SatisFiyati = p.SatisFiyati;
            urunnnn.Stok = p.Stok;
            urunnnn.UrunAdi = p.UrunAdi;
            urunnnn.UrunGorsel = p.UrunGorsel;
            q.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}