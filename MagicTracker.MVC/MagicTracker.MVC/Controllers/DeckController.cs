using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagicTracker.Models;
using MagicTracker.Services;

namespace MagicTracker.MVC.Controllers
{
    public class DeckController : Controller
    {
        private DeckServices CreateDeckService()
        {
            var deckService = new DeckServices();
            return deckService;
        }

        // GET: Deck
        public ActionResult Index()
        {
            var service = CreateDeckService();
            var model = service.GetDecks();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeckCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateDeckService();

            if (svc.CreateDeck(model))
            {
                TempData["SaveResult"] = "Your Deck was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Deck Couldn't be created");

            return View(model);
        }
    }
}