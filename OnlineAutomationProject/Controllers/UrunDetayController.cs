using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAutomationProject.Models.Siniflar;

namespace OnlineAutomationProject.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay

        Context c = new Context();
        public ActionResult Index()
        {

            Class1 cs = new Class1();
           
            cs.Deger1 = c.Uruns.Where(x => x.UrunID == 25).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayID == 1).ToList();
            return View(cs);
        }
    }
} 