using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RAAST_web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "On this website you can track our boat's live location. You can also post a comment in our blog or take a look at some data!";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Credits()
        {
            ViewBag.Message = "credits";

            return View();
        }

        public ActionResult Test_Yannick()
        {
            ViewBag.Message = "Taaie zaak";

            return View();
        }
        public ActionResult InfoBoot()
        {
            ViewBag.Message = "Dit is de informatie van onze boot.";


            return View();
        }
    }
}