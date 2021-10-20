using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagicTracker.Models;
using MagicTracker.Services;

namespace MagicTracker.MVC.Controllers
{
    public class SideboardController : Controller
    {
        private SideboardServices CreateSideboardService()
        {
            var sideService = new SideboardServices();
            return sideService;
        }

        // GET: Deck
        public ActionResult Index()
        {
            var service = CreateSideboardService();
            var model = service.GetSideboards();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SideboardCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateSideboardService();

            if (svc.CreateSideboard(model))
            {
                TempData["SaveResult"] = "Your Deck was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Deck Couldn't be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSideboardService();
            var model = svc.GetSideboardById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateSideboardService();
            var detail = svc.GetSideboardById(id);
            var model =
                new SideboardEdit
                {
                    SideboardId = detail.SideboardId,
                    CardCount = detail.CardCount,
                    CardStyle = detail.CardStyle,
                    DeckId = detail.DeckId
                };

            return View(model);
        }

        // Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SideboardEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SideboardId != id)
            {
                ModelState.AddModelError("", "Id does not match");
                return View(model);
            }

            var svc = CreateSideboardService();

            if (svc.UpdateSideboard(model))
            {
                TempData["SaveResult"] = "Your sideboard was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your sideboard could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSideboardService();
            var model = svc.GetSideboardById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSideboard(int id)
        {
            var svc = CreateSideboardService();

            svc.DeleteSideboard(id);

            TempData["Save Result"] = "Sideboard was Deleted";

            return RedirectToAction("Index");
        }
    }
}