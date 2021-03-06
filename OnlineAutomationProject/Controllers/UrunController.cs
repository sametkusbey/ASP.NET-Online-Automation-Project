using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAutomationProject.Models.Siniflar;

namespace OnlineAutomationProject.Controllers
{


    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList(); 
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()   
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,  
                                               Value = x.KategoriID.ToString() 
                                           }).ToList();
            ViewBag.dgr1 = deger1; 
            return View();
        }


        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            u.Durum = true;
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {

            var urn = c.Uruns.Find(id);
            urn.Durum = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()   
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,  
                                               Value = x.KategoriID.ToString() 
                                           }).ToList();
            ViewBag.dgr1 = deger1; 

            var urundeger = c.Uruns.Find(id);

            return View("UrunGetir", urundeger);
        }


        public ActionResult UrunGuncelle(Urun p)
        {

            var urunuptdate = c.Uruns.Find(p.UrunID); 
            urunuptdate.AlisFiyat = p.AlisFiyat; 
            urunuptdate.SatisFiyat = p.SatisFiyat;
            urunuptdate.Marka = p.Marka;
            urunuptdate.kategoriid = p.kategoriid;
            urunuptdate.UrunAd = p.UrunAd;
            urunuptdate.UrunGorsel = p.UrunGorsel;
            urunuptdate.Stok = p.Stok;
            urunuptdate.Durum = p.Durum;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {

            var degerler = c.Uruns.ToList();
            return View(degerler);
        }

    }
}