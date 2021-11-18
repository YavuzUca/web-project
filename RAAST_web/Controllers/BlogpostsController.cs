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
    public class BlogpostsController : Controller
    {
        private Data db = new Data();

        // GET: Blogposts
        public ActionResult Index()
        {
            var blogposts = db.Blogposts.Include(b => b.User);
            return View(blogposts.ToList());
        }

        // GET: Blogposts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogpost blogpost = db.Blogposts.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            return View(blogpost);
        }

        // GET: Blogposts/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "Id", "fullName");
            return View();
        }

        // POST: Blogposts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,user_id,title,content,cu_date,slug")] Blogpost blogpost)
        {
            if (ModelState.IsValid)
            {
                db.Blogposts.Add(blogpost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Users, "Id", "fullName", blogpost.user_id);
            return View(blogpost);
        }

        // GET: Blogposts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogpost blogpost = db.Blogposts.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Users, "Id", "fullName", blogpost.user_id);
            return View(blogpost);
        }

        // POST: Blogposts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,user_id,title,content,cu_date,slug")] Blogpost blogpost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogpost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "Id", "fullName", blogpost.user_id);
            return View(blogpost);
        }

        // GET: Blogposts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogpost blogpost = db.Blogposts.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            return View(blogpost);
        }

        // POST: Blogposts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blogpost blogpost = db.Blogposts.Find(id);
            db.Blogposts.Remove(blogpost);
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
