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


            return View();
        }
        private Data db = new Data();
        public ActionResult BlogPost()
        {
            var blogposts = db.Blogposts.Include(b => b.User);
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
    }
}