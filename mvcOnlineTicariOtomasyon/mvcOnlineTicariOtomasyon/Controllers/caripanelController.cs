using mvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class caripanelController : Controller
    {
        // GET: caripanel
        Context q = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = q.Caris.Where(x => x.CariMail == mail).ToList();
            ViewBag.m = mail;
            var mailid = q.Caris.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamSatis = q.SatisHareketis.Where(x => x.Cariid == mailid).Count();

            ViewBag.tSatis = toplamSatis;
            if (toplamSatis != 0)

            {

                var toplamOdeme = q.SatisHareketis.Where(x => x.Cariid == mailid).Select(y => y.ToplamTutar).Sum();

                ViewBag.tTutar = toplamOdeme;
                var toplamUrun = q.SatisHareketis.Where(x => x.Cariid == mailid).Select(y => y.Adet).Sum();

                ViewBag.tUrun = toplamUrun;

            }

            else

            {

                ViewBag.tTutar = 0;

                ViewBag.tUrun = 0;

            }



            //var toplamsatis = q.SatisHareketis.Where(x => x.Cariid == mailid).Count();
            //ViewBag.toplamsatis = toplamsatis;
            //var toplamtutar = q.SatisHareketis.Where(x => x.Cariid == mailid).Sum(y => y.ToplamTutar);
            //ViewBag.toplamtutar = toplamtutar;
            //var toplamurunsayisi = q.SatisHareketis.Where(x => x.Cariid == mailid).Sum(y => y.Adet);
            //ViewBag.toplamurunsayisi = toplamurunsayisi;
            var adsoyad = q.Caris.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = q.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = q.SatisHareketis.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = q.mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.MesajID).ToList();
            var gelensayisi = q.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = q.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = q.mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelensayisi = q.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = q.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = q.mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelensayisi = q.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = q.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);

        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = q.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = q.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gidensayisi;

            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = mail;
            q.mesajlars.Add(m);
            q.SaveChanges();
            return View();

        }
        public ActionResult KargoTakip(string p)
        {
            var k = from x in q.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }
            //var kargolar = q.KargoDetays.ToList();
            return View(k.ToList());


        }
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = q.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = q.Caris.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var caribulma = q.Caris.Find(id);
            return PartialView("Partial1", caribulma);

        }
        public ActionResult Partial2()
        {
            var mail = (string)Session["CariMail"];
            var veriler = q.mesajlars.Where(x => x.Alici == mail).ToList();
            return PartialView(veriler);
        }
        public ActionResult Partial3()
        {
            var veriler = q.mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult BilgileriGuncelleme(Cari cr)
        {
            var cari = q.Caris.Find(cr.CariID);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.CariSifre = cr.CariSifre;
            q.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}