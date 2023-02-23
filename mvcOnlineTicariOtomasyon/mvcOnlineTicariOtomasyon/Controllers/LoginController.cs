
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using mvcOnlineTicariOtomasyon.Models.Classes;
namespace mvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context q = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()

        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cari p)

        {
            q.Caris.Add(p);
            q.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult Login1()

        {

            return View();
        }
        [HttpPost]
        public ActionResult Login1(Cari c)

        {
            var bilgiler = q.Caris.FirstOrDefault(x => x.CariMail == c.CariMail
              && x.CariSifre == c.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "caripanel");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var bilgiler = q.Admins.FirstOrDefault(x => x.KullaniciAdi == a.KullaniciAdi
                 && x.Sifre == a.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Kategori");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


        }
    }
   

}
