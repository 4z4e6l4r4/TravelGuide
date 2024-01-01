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
using SeyahatRehberi.Entity.Interface;
using SeyahatRehberi.Models;

namespace SeyahatRehberi.Controllers
{
    public class RoleController : Controller
    {
        RoleProccess roleProccess = new RoleProccess();

        // GET: Role
        public ActionResult Index()
        {
            return View(roleProccess.GetAll().ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = roleProccess.Get(id);

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {

            string result = roleProccess.Add(role);

            ViewData["Message"] = result;

            return View();
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = roleProccess.Get(id);

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //// POST: Role/Edit/5
        //// Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        //// Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            bool result = roleProccess.Update(role, role.Id);
            ViewData["Message"] = result ? "Düzenleme Başarılı" : "Düzenleme Başarısız";
            return View(role);
        }

        //// GET: Role/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = roleProccess.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //// POST: Role/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            bool result = roleProccess.Delete(id);
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
