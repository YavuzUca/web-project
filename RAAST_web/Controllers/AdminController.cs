using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RAAST_web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Editor
        public ActionResult AddEditor()
        {
            return View();
        }
        public ActionResult Verify()
        {
            return View("Verify");
        }
    }
}