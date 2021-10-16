using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagicTracker.MVC.Controllers
{
    public class DeckController : Controller
    {
        // GET: Deck
        public ActionResult Index()
        {
            return View();
        }
    }
}