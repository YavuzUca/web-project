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
            var blogposts = db.Blogposts.Include(b => b.User);
            return View(blogposts.ToList());
        }
        public ActionResult BlogPostContent(int id, string title, string content)
        {
            var blogposts = db.Blogposts.Find(id);
            return View(blogposts);
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
                db.Newsletters.Add(newsletter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsletter);
        }
    }
}