using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;
namespace mvcOnlineTicariOtomasyon.Controllers

{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context q = new Context();
        public ActionResult Index()
        {
            var values = q.Kategoris.ToList();
            return View(values);
        }
        [HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        public ActionResult KategoriEkleme()
        {
            return View();

        }
        [HttpPost] //butona tıklandığında çalışacak
        public ActionResult KategoriEkleme(Kategori b)
        {

            q.Kategoris.Add(b);
            q.SaveChanges();

            TempData["kategoriekleme"] = "kayıt başarılı ";
            return RedirectToAction("Index");

        }

       
        public ActionResult KategoriSilme(int id)
        {
            try
            {
                
                
                    var kategri = q.Kategoris.Find(id);
                    q.Kategoris.Remove(kategri);
                    q.SaveChanges();
                 return RedirectToAction("Index");
                
            }
           
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

            //TempData["kategorisilme"] = "  ";
            //var kategri = q.Kategoris.Find(id);
            //q.Kategoris.Remove(kategri);
            //q.SaveChanges();
            //return RedirectToAction("Index");

        }

        //var kategri = q.Kategoris.Find(id);
        //    q.Kategoris.Remove(kategri);
        //q.SaveChanges();


        public ActionResult KategoriGetirme(int id)
        {
            var kategorii = q.Kategoris.Find(id);
            return View("KategoriGetirme", kategorii);
        }
        public ActionResult KategoriGuncelleme(Kategori b)
        {
            var kategor = q.Kategoris.Find(b.KategoriID);
            kategor.KategoriAd = b.KategoriAd;
            q.SaveChanges();

            TempData["kategoriguncelleme"] = "kayıt başarılı ";
            return RedirectToAction("Index");

        }
    }

}
