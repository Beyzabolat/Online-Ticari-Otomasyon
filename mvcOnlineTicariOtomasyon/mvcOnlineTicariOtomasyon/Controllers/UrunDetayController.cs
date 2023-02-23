using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context q = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            // var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
            cs.Deger1 = q.Urunlers.Where(x => x.UrunID == 1).ToList();
            cs.Deger2 = q.Detays.Where(y => y.DetayID == 1).ToList();
            return View(cs);

        }
    }
}