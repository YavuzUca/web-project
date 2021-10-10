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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test_Yannick()
        {
            ViewBag.Message = "Yannick heeft hoofdpijn van mensen die niks snappen van git";

        public ActionResult InfoBoot()
        {
            ViewBag.Message = "Dit is de informatie van onze boot.";


            return View();
        }
    }
}