﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineAutomationProject.Models.Siniflar;

namespace OnlineAutomationProject.Controllers
{
    public class LoginController : Controller
    {

        Context c = new Context();
        // GET: Login
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
        public PartialViewResult Partial1(Cariler p)  
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }


        [HttpGet]
        public ActionResult CariLogin1()
        {


            return View();
        }

        [HttpPost]

        public ActionResult Carilogin1(Cariler p)
        {

            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);  
            if (bilgiler != null)  
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);  
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }

            else
            {

                return View();
            }
            
        }
    }
}