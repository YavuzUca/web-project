using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RAAST_web.Models;

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
            return View("Success");
        }

        public ActionResult ShowEditors()
        {
            var test = new Data();

            List<User> users = new List<User>();

            foreach (User u in test.Users)
            {
                users.Add(u);
            }

            return View(users);
        }

    }
}