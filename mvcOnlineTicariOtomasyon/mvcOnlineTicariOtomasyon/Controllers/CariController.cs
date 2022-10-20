using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context q = new Context();
        public ActionResult Index()
        {
            var Dgerleeeer = q.Caris.Where(x => x.Durum == true).ToList();
            return View(Dgerleeeer);
        }
        [HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        public ActionResult CariEkleme()
        {
            return View();

        }
        [HttpPost] //butona tıklandığında çalışacak
        public ActionResult CariEkleme(Cari p)
        {
            p.Durum = true;
            q.Caris.Add(p);
            q.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSilme(int id)
        {
            var cr = q.Caris.Find(id);
            cr.Durum = false;
            q.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetirme(int id)
        {
            var cariii = q.Caris.Find(id);
            return View("CariGetirme", cariii);
        }
        public ActionResult CariGuncelleme(Cari p)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetirme");
            }
            var cariii = q.Caris.Find(p.CariID);
            cariii.CariAd = p.CariAd;
            cariii.CariSoyad = p.CariSoyad;
            cariii.CariSehir = p.CariSehir;
            cariii.CariMail = p.CariMail;
            q.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriSatis(int id)
        {
            var degerrrr = q.SatisHareketis.Where(x => x.Cariid == id).ToList();
            var crr = q.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = crr;
            return View(degerrrr);
        }
    }
}