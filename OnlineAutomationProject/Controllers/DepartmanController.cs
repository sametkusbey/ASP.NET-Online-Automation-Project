using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAutomationProject.Models.Siniflar;

namespace OnlineAutomationProject.Controllers
{
    public class DepartmanController : Controller
    {

        Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {

            var departrmanlar = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(departrmanlar);
            
        }

        [HttpGet]  
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult DepartmanEkle(Departman d)  
        {

            c.Departmans.Add(d);  
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {

            var departmanlars = c.Departmans.Find(id);
            departmanlars.Durum = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departmanguncelle = c.Departmans.Find(id);

            return View("DepartmanGetir", departmanguncelle);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var departmanguncelle = c.Departmans.Find(d.Departmanid);
            departmanguncelle.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();  
            return View(degerler);

            //var dpt = c.Departmans.Where(x => x.Departmanid == id).Select(y => y.DepartmanAd); 
            //ViewBag.d = dpt;
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
         
            return View(degerler);

        }

    }
}