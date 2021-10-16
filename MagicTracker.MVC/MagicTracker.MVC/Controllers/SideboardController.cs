using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagicTracker.MVC.Controllers
{
    public class SideboardController : Controller
    {
        // GET: Sideboard
        public ActionResult Index()
        {
            return View();
        }
    }
}