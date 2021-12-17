﻿using System.Linq;
using System.Web.Mvc;
using RAAST_web.Models;
using System.Data.Entity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RAAST_web.Controllers
{
    public class HomeController : Controller
    {
        private Data db = new Data();
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

        public async Task<ActionResult> InfoBoot()
        {
            ViewBag.Message = "This is the information about our boat.";
            BoatInfoController data = new BoatInfoController();
            await data.GetBoatInfo();

            return View(db.Boat_Info);

        }
        [Route("Home/BlogPost")]
        public ActionResult BlogPost()
        {
            var blogposts = db.Blogpost.Include(b => b.AspNetUsers);
            return View(blogposts.ToList());
        }
        [Route("Home/Blogpost/{id}")]
        public ActionResult BlogPostContent(int id)
        {
            ViewBag.id = id;

            var mymodel = db.Blogpost.Find(id);
            //handle data
            return View(mymodel);
        }
        
        // POST: Blogposts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,email")] Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                db.Newsletter.Add(newsletter);
                db.SaveChanges();
                ViewBag.Message = "Thank you for subscribing!";
                return View();
            }
            else
                ViewBag.Message = "Please enter a valid email-address";
                return View();

        }
    }
}