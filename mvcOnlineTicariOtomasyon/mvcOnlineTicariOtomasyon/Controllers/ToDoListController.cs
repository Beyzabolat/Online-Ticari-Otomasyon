using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        Context q = new Context();
        public ActionResult Index()
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