using SeyahatRehberi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeyahatRehberi.Controllers
{
    public class PanelController : Controller
    {

        // GET: Panel

        DataContext db = new DataContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}