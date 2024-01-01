using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SeyahatRehberi.Entity;
using SeyahatRehberi.Models;

namespace SeyahatRehberi.Controllers
{
    public class UsersController : Controller
    {
        UserProccess userProccess = new UserProccess();

        // GET: Users
        public ActionResult Index()
        {
            
            return View(userProccess.GetAll().ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var users = userProccess.Get(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users users)
        {
            string result = userProccess.Add(users);

            ViewData["Message"] = result;

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var users = userProccess.Get(id);

            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users users)
        {
            bool result = userProccess.Update(users, users.Id);
            ViewData["Message"] = result ? "Düzenleme Başarılı" : "Düzenleme Başarısız";
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var users = userProccess.Get(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool result = userProccess.Delete(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Delete", id);
            }
        }






        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
