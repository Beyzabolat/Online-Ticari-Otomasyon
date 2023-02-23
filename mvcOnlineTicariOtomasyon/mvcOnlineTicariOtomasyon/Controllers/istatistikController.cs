using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        Context q = new Context();
        public ActionResult Index()
        {
            var degeer1 = q.SatisHareketis.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d1 = degeer1;

            DateTime todayy = DateTime.Today;
            var degeer2 = q.SatisHareketis.Count(x => x.Tarih == todayy).ToString();
            ViewBag.d2 = degeer2;

            var degeer3 = q.SatisHareketis.Where(x => x.Tarih == todayy).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d3 = degeer3;

            var degeer4 = q.SatisHareketis.Sum(x => x.Urunler.Stok).ToString();
            ViewBag.d4 = degeer4;


            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in q.Caris
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            
            return View(sorgu.ToList());
    }
        public PartialViewResult Partial1()
        {
            var sorgu2= from x in q.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new SinifGrup2
                        {
                            Departman = g.Key,
                            Sayi = g.Count()
                        };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu3 = q.Caris.ToList();
            return PartialView(sorgu3);
        }
        public PartialViewResult Partial3()
        {
            var sorgu4 = q.Urunlers.ToList();
            return PartialView(sorgu4);
        }
        public PartialViewResult Partial4()
        {
            var sorgu5 = from x in q.Urunlers
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             Marka = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu5.ToList());
        }
    }
}



