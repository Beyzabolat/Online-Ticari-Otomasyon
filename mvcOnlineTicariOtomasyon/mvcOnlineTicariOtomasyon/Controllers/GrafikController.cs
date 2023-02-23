using mvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
     
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Index2()
        {
            var grafikcizz = new Chart(600, 600);
            grafikcizz.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries
                ("Değerler",
                xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" },
                yValues: new[]
                {
                    88.90,98
                }).Write();
            return File(grafikcizz.ToWebImage().GetBytes(), "image/jpeg");
        }
        Context q = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = q.Urunlers.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAdi));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        } 
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);

        }
        public List<sinif1> UrunListesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
                {
                urunad = "Bilgisayar",
                stok = 120
            });
            snf.Add(new sinif1()
                {
                urunad = "Mobilya",
                stok = 128
            });
            snf.Add(new sinif1()
                {
                urunad = "Küçükev aletleri",
                stok = 200
            });
            snf.Add(new sinif1()
                {
                urunad = "Mobil Cihazlar",
                stok = 250
            });
            return snf;
        }
        Context m = new Context();
        public ActionResult Index5()
        {
            var degeer1 = m.SatisHareketis.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d1 = degeer1;

            DateTime todayy = DateTime.Today;
            var degeer2 = m.SatisHareketis.Count(x => x.Tarih == todayy).ToString();
            ViewBag.d2 = degeer2;

            var degeer3 = m.SatisHareketis.Where(x => x.Tarih == todayy).Sum(y => (decimal?)y.ToplamTutar).ToString();
            ViewBag.d3 = degeer3;

            var degeer4 = m.SatisHareketis.Sum(x => x.Urunler.Stok).ToString();
            ViewBag.d4 = degeer4;

            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);

        }
        public List<sinif2> UrunListesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            using(var context= new Context())
            {
                snf = context.Urunlers.Select(x => new sinif2
                {
                    urn = x.UrunAdi,
                    stk = x.Stok
                }).ToList();
            }
            return snf;
        }
        public ActionResult VisualizeUrunResult3()
        {
            return Json(UrunListesi3(), JsonRequestBehavior.AllowGet);

        }
        public List<sinif3> UrunListesi3()
        {
            List<sinif3> snf = new List<sinif3>();
            using(var context= new Context())
            {
                snf = context.SatisHareketis.Select(x => new sinif3
                {
                    satis = x.Urunler.UrunAdi,
                    adet = x.ToplamTutar
                }).ToList();
            }
            return snf;
        }
        public ActionResult ToDoList()
        {
            var deger1 = q.Caris.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = q.Urunlers.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = q.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = (from x in q.Caris select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;

            var yapilacaklar = q.ToDoLists.ToList();




            return View(yapilacaklar);



        }
    }
}