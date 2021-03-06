using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAutomationProject.Models.Siniflar;

namespace OnlineAutomationProject.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {

            var degerler = c.Faturalars.ToList();
            return View(degerler);

        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {

            return View();
        }

        [HttpPost]

        public ActionResult FaturaEkle(Faturalar f)
        {
            f.Tarih = DateTime.Parse(DateTime.Now.ToShortTimeString());
            c.Faturalars.Add(f);
            c.SaveChanges();
          
            
            return RedirectToAction("Index");

        }
        public ActionResult FaturaGetir(int id)
        {
            var degerler = c.Faturalars.Find(id);

            return View("FaturaGetir", degerler);
        }

        public ActionResult FaturaGuncelle(Faturalar ftrupd)
        {

            var degerler = c.Faturalars.Find(ftrupd.FaturaID);
            degerler.FaturaSeriNo = ftrupd.FaturaSeriNo;
            degerler.FaturaSiraNo = ftrupd.FaturaSiraNo;
            degerler.VergiDairesi = ftrupd.VergiDairesi;
            degerler.Saat = ftrupd.Saat;
            degerler.Toplam = ftrupd.Toplam;
            degerler.TeslimAlan = ftrupd.TeslimAlan;
            degerler.TeslimEden = ftrupd.TeslimEden;
            ftrupd.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaveChanges();
            

            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
        
            var degerler = c.FaturaKalems.Where(x => x.FaturaID == id).ToList();  
            return View(degerler);
        }

    }
}