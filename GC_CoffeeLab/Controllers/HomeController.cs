using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GC_CoffeeLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //this will go to my registration page
        //1.Link/2.ActionResult/3.View
        public ActionResult Registration()
        {
            
            return View();
        }

        public ActionResult Welcome(string first = "First", string last = "Last", int phone = 111-222-3333, 
                                    string email = "email@whatever.com", string password = "demc359")
        {
            //ActionResult
            ViewBag.data = first;
            ViewBag.last = last;
            ViewBag.phone = phone;
            ViewBag.email = email;
            ViewBag.password = password;
            return View();
        }
    }
}