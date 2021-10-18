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

        public ActionResult Details(int id)
        {
            var svc = CreateDeckService();
            var model = svc.GetDeckById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateDeckService();
            var detail = svc.GetDeckById(id);
            var model =
                new DeckEdit
                {
                    DeckId = detail.DeckId,
                    DeckType = detail.DeckType,
                    CardCount = detail.CardCount,
                    DeckStyle = detail.DeckStyle,
                    Commander = detail.Commander,
                    Companion = detail.Companion,
                    
                };

            return View(model);
        }

        // Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DeckEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DeckId != id)
            {
                ModelState.AddModelError("", "Id does not match");
                return View(model);
            }

            var svc = CreateDeckService();

            if (svc.UpdateDeck(model))
            {
                TempData["SaveResult"] = "Your deck was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your card could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDeckService();
            var model = svc.GetDeckById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDeck(int id)
        {
            var svc = CreateDeckService();

            svc.DeleteDeck(id);

            TempData["Save Result"] = "Card was Deleted";

            return RedirectToAction("Index");
        }
    }
}