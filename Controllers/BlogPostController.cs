using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeyahatRehberi.Entity;
using SeyahatRehberi.Models;

namespace SeyahatRehberi.Controllers
{
    public class BlogPostController : Controller
    {
        BlogProccess blogProccess = new BlogProccess();
        DataContext db = new DataContext();

        // GET: BlogPost
        public ActionResult Index()
        {
            return View(blogProccess.GetAll().ToList());
        }

        // GET: BlogPost/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var blogPosts = blogProccess.Get(id);
            if (blogPosts == null)
            {
                return HttpNotFound();
            }
            return View(blogPosts);
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPost/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( BlogPosts blogPosts)
        {
            string result = blogProccess.Add(blogPosts);

            ViewData["Message"] = result;

            return View(blogPosts);
        }

        // GET: BlogPost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPosts blogPosts = db.BlogPosts.Find(id);
            if (blogPosts == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", blogPosts.UserId);
            return View(blogPosts);
        }

        // POST: BlogPost/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,PostedDate,UserId,Name,Description,Image,IsStatus,IsDelete")] BlogPosts blogPosts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogPosts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Password", blogPosts.UserId);
            return View(blogPosts);
        }

        // GET: BlogPost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPosts blogPosts = db.BlogPosts.Find(id);
            if (blogPosts == null)
            {
                return HttpNotFound();
            }
            return View(blogPosts);
        }

        // POST: BlogPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPosts blogPosts = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(blogPosts);
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
