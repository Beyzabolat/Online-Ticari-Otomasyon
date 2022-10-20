﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context q = new Context();
        public ActionResult Index()
        {
            var degerler = q.Departmans.Where(x => x.Durum == true).ToList();

            return View(degerler);
        }
        //[HttpGet]  //sayfa çalıştığında boş olarak bunu açacak
        //public ActionResult DepartmanEkleme()
        //{
        //    return View();

        //}
        //[HttpPost] //butona tıklandığında çalışacak
        //public ActionResult KategoriEkleme(Kategori b)
        //{
        //    q.Kategoris.Add(b);
        //    q.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult DepartmanEkleme()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult DepartmanEkleme(Departman d)
        {
            d.Durum = true;
            q.Departmans.Add(d);
            q.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DepartmanSilme(int id)
        {
            var depa = q.Departmans.Find(id);
            depa.Durum = false;
            q.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetirme(int id)
        {
            var dprtmn = q.Departmans.Find(id);
            return View("DepartmanGetirme", dprtmn);
        }
        public ActionResult DepartmanGuncelleme(Departman b)
        {
            var dprt = q.Departmans.Find(b.DepartmanID);
            dprt.DepartmanAd = b.DepartmanAd;
            q.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = q.Personels.Where(x => x.Departmanid == id).ToList();
            
            var dpt = q.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            
            ViewBag.d = dpt;
            return View(degerler);

        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler= q.SatisHareketis.Where(x => x.Personelid == id).ToList();
            var per = q.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.dp = per;
            return View(degerler);
        }
       
    }
} 