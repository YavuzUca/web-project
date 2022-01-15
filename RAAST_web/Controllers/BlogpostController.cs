using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RAAST_web.Models;
using Microsoft.AspNet.Identity;

namespace RAAST_web.Controllers
{
    [Authorize(Roles = "Admin, Editor" ) ]
    public class BlogpostController : Controller
    {
        private Data db = new Data();

        // GET: Blogpost

        public ActionResult Index()
        {
            var blogpost = db.Blogpost.Include(b => b.AspNetUsers);
            return View(blogpost.ToList());
        }

        // GET: Blogpost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogpost blogpost = db.Blogpost.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            return View(blogpost);
        }

        // GET: Blogpost/Create
        public ActionResult Create()
        {
            ViewBag.asp_user_id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Time = DateTime.Now;
            var user = User.Identity.GetUserId();
            ViewBag.User = user;
            return View();
        }

        // POST: Blogpost/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,title,content,cu_date,slug,asp_user_id")] Blogpost blogpost)
        {
            if (ModelState.IsValid)
            {
                db.Blogpost.Add(blogpost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.asp_user_id = new SelectList(db.AspNetUsers, "Id", "Email", blogpost.asp_user_id);
            return View(blogpost);
        }

        // GET: Blogpost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogpost blogpost = db.Blogpost.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            ViewBag.asp_user_id = new SelectList(db.AspNetUsers, "Id", "Email", blogpost.asp_user_id);
            return View(blogpost);
        }

        // POST: Blogpost/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,title,content,cu_date,slug,asp_user_id")] Blogpost blogpost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogpost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.asp_user_id = new SelectList(db.AspNetUsers, "Id", "Email", blogpost.asp_user_id);
            return View(blogpost);
        }

        // GET: Blogpost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blogpost blogpost = db.Blogpost.Find(id);
            if (blogpost == null)
            {
                return HttpNotFound();
            }
            return View(blogpost);
        }

        // POST: Blogpost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blogpost blogpost = db.Blogpost.Find(id);
            db.Blogpost.Remove(blogpost);
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
