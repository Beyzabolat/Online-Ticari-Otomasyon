using mvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context q = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in q.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(y => y.TakipKodu.Contains(p));
            }
            //var kargolar = q.KargoDetays.ToList();
            return View(k.ToList());
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "G", "H" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakterler.Length);
            k2 = rnd.Next(0, karakterler.Length);
            k3 = rnd.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkodu = kod;

            List<SelectListItem> deger2 = (from x in q.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();

            ViewBag.dgr2 = deger2;
            return View();
        }


        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {

            q.KargoDetays.Add(d);
            q.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult KargoTakip(string id)
        {
           
            var degerler = q.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);

        }
    }
}