using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAutomationProject.Models.Siniflar;

namespace OnlineAutomationProject.Controllers
{
    public class CariController : Controller
    {

        Context c = new Context();
        // GET: Cari
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.Durum==true).ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {

            return View();
        } 

        [HttpPost]
        public ActionResult CariEkle(Cariler cr)

        {
            cr.Durum = true; 
            c.Carilers.Add(cr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var carisil = c.Carilers.Find(id);
            carisil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {

            var carilers = c.Carilers.Find(id);
            return View("CariGetir", carilers);

        }

        public ActionResult CariGuncelle(Cariler cariparametre)
        {

            if (!ModelState.IsValid)  
            {
                
                return View("CariGetir");
                
            }
            var carilers1 = c.Carilers.Find(cariparametre.CariID);
            carilers1.CariAd = cariparametre.CariAd;
            carilers1.CariSoyad = cariparametre.CariSoyad;
            carilers1.CariSehir = cariparametre.CariSehir;
            carilers1.CariMail = cariparametre.CariMail;
            c.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}