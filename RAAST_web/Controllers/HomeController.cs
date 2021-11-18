using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RAAST_web.Models;

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

        public ActionResult Credits()
        {
            ViewBag.Message = "credits";

            return View();
        }

        public ActionResult InfoBoot()
        {
            ViewBag.Message = "This is the information about our boat.";


            return View();
        }
        public ActionResult BlogPost()
        {
            return View();
        }
        public ActionResult BlogPostContent(int id, string title, string content)
        {
            ViewBag.idFromUrl = id;
            Models.Blogpost blogpost = new Models.Blogpost();
            ViewBag.Title = title;
            ViewBag.Description = content;
            
            //handle data
            return View();
        }
    }
}