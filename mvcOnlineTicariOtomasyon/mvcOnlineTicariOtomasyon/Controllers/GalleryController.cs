using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context q = new Context();
        public ActionResult Index()
        {
            var deger = q.Urunlers.ToList();
            return View(deger);
        }
    }
}