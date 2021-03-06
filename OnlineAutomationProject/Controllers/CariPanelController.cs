using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineAutomationProject.Models.Siniflar;

namespace OnlineAutomationProject.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel

        [Authorize]  
        public ActionResult Index()
        {
            return View();
        }
    }
}