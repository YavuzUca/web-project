using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RAAST_web.Models;

namespace RAAST_web.Controllers
{
    public class CommentController : Controller
    {
        private Data db = new Data();

        [Authorize(Roles = "Admin, Editor")]
        // GET: Comment
        public ActionResult Index()
        {
            var comment = db.Comment.Include(c => c.Blogpost);
            return View(comment.ToList());
        }

        [Authorize(Roles = "Admin, Editor")]
        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comment/Create
        public ActionResult Create(int blogpostid)
        {
            ViewBag.blogpost_id = new SelectList(db.Blogpost, "Id", "title");

            ViewBag.Time = DateTime.Now;
            ViewBag.blog_id = blogpostid;
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create([Bind(Include = "Id,blogpost_id,commenter,content,cu_date")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comment.Add(comment);
                db.SaveChanges();
                if (Request.IsAuthenticated)
                {

                    return RedirectToAction("Index");
                }
                return RedirectToAction("BlogPost", "Home");
            }

            ViewBag.blogpost_id = new SelectList(db.Blogpost, "Id", "title", comment.blogpost_id);
            return View(comment);
        }

        // GET: Comment/Edit/5

        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.blogpost_id = new SelectList(db.Blogpost, "Id", "title", comment.blogpost_id);
            return View(comment);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit([Bind(Include = "Id,blogpost_id,commenter,content,cu_date")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.blogpost_id = new SelectList(db.Blogpost, "Id", "title", comment.blogpost_id);
            return View(comment);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comment.Find(id);
            db.Comment.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
