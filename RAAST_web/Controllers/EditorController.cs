using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RAAST_web.Models;

namespace RAAST_web.Controllers
{
    public class EditorController : Controller
    {
        public ActionResult ShowEditors()
        {
            var test = new Model1();

            List<User> users = new List<User>();

            foreach( User u in test.Users)
            {
                users.Add(u);
            }

            return View(users);
        }



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
