using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using System.Data;
using RAAST_web.Models;

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
    }
}
