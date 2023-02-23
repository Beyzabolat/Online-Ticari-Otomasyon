using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context q = new Context();
        public ActionResult Index()
        {
            var list = q.Faturalars.ToList();
            return View(list);
        }

        [HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        public ActionResult FaturaEkleme()
        {
            
            return View();

        }
        [HttpPost] //butona tıklandığında çalışacak
        public ActionResult FaturaEkleme(Faturalar f)
        {
            q.Faturalars.Add(f);
            q.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetirme(int id)
        {
            var ftr = q.Faturalars.Find(id);
            return View("FaturaGetirme", ftr);
        }
        public ActionResult FaturaGuncelleme(Faturalar f)
        {
            var ftrr = q.Faturalars.Find(f.FaturaID);
            ftrr.FaturaSeriNo = f.FaturaSeriNo;
            ftrr.FaturaSıraNo = f.FaturaSıraNo;
            ftrr.FaturaTarih = f.FaturaTarih;
            ftrr.FaturaSaat = f.FaturaSaat;
            ftrr.TeslimAlan = f.TeslimAlan;
            ftrr.TeslimEden = f.TeslimEden;
            ftrr.VergiDairesi = f.VergiDairesi;
            q.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = q.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);

        }
        [HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        public ActionResult KalemEkleme()
        {

            return View();

        }
        [HttpPost] //butona tıklandığında çalışacak
        public ActionResult KalemEkleme(FaturaKalem f)
        {
            q.FaturaKalems.Add(f);
            q.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik(FaturaKalem f)
        {
            Class2 cs = new Class2();
            cs.deger1 = q.Faturalars.ToList();
            cs.deger2 = q.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSıraNo, DateTime Tarih, string VergiDairesi, string Saat, string TeslimEden, string TeslimAlan, string Toplam, FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSıraNo = FaturaSıraNo;
            f.FaturaTarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.FaturaSaat = Saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.FaturaToplam = decimal.Parse(Toplam);
            q.Faturalars.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = x.Aciklama;
                fk.Birimfiyat = x.Birimfiyat;
                fk.Faturaid = x.FaturaKalemID;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                q.FaturaKalems.Add(fk);
            }
            q.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}