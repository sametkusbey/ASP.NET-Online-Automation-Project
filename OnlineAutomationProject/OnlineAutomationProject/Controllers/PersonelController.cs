using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAutomationProject.Models.Siniflar;

namespace OnlineAutomationProject.Controllers
{
    public class PersonelController : Controller
    {

        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
           
            return View(degerler);
        }

        public ActionResult PersonelListe()
        {

            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        public ActionResult PersonelGetir(int id)
        {

            var degerler = c.Personels.Find(id);

            return View("PersonelGetir", degerler);

        }

        public ActionResult PersonelGuncelle(Personel p)
        {

            var persupt = c.Personels.Find(p.PersonelID);
            persupt.PersonelAd = p.PersonelAd;
            persupt.PersonelSoyad = p.PersonelSoyad;
            persupt.PersonelGorsel = p.PersonelGorsel;
           
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}