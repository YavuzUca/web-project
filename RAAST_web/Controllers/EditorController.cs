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
        public ActionResult AddPost()
        {
            return View();
        }
        public ActionResult Verify()
        {
            return View("Verify");
        }
    }
}