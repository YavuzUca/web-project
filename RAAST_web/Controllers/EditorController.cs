using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RAAST_web.Controllers
{
    public class EditorController : Controller
    {
        // GET: Editor
        public ActionResult AddArticle()
        {
            return View();
        }

        public ActionResult AddPost()
        {
            return View();
        }

        public ActionResult Verify()
        {
            return View("Success");
        }
        public ActionResult BlogPost_Editor()
        {
            return View();
        }
        public ActionResult BlogPostContent(int id)
        {

            ViewBag.Message = "This is the information about our boat.";

            ViewBag.idFromUrl = id;
            string res = "";
            for (int i = 0; i < 100; i++) { res += id.ToString(); }
            ViewBag.testC = res;
            //handle data
            return View();
        }
    }
}
