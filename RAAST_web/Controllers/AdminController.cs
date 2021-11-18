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
        [HttpPost]
        public ActionResult AddEditor(User user)
        {
            Data data = new Data();
            data.Users.Add(user);
            data.SaveChanges();
            ViewBag.message = "User addded!";
            return View();
        }
        public ActionResult Verify()
        {
            return View("Success");
        }

        public ActionResult ShowEditors()
        {
            var test = new Data();

            
            return View(test.Users);
        }
        public ActionResult ShowClientList()
        {
            var test = new Data();

            List<Newsletter> newsletters = new List<Newsletter>();

            foreach (Newsletter u in test.Newsletters)
            {
                newsletters.Add(u);
            }

            return View(newsletters);
        }

    }
}