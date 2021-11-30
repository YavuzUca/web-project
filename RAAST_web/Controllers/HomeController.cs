using System.Linq;
using System.Web.Mvc;
using RAAST_web.Models;
using System.Data.Entity;

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

            var data = new Data();

            return View(data.Boat_Info);

        }
        private Data db = new Data();
        public ActionResult BlogPost()
        {
            var blogposts = db.Blogpost.Include(b => b.AspNetUsers);
            return View(blogposts.ToList());
        }
        public ActionResult BlogPostContent(int id, string title, string content)
        {
            ViewBag.idFromUrl = id;
            ViewBag.Title = title;
            ViewBag.Description = content;

            //handle data
            return View();
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
                return RedirectToAction("Index");
            }

            return View(newsletter);
        }
    }
}