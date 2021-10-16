using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagicTracker.Data;
using MagicTracker.Models;
using MagicTracker.Services;

namespace MagicTracker.MVC.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private CardServices CreateCardService()
        {
            var cardService = new CardServices();
            return cardService;
        }
        // GET: Card
        public ActionResult Index()
        {
            var service = CreateCardService();
            var model = service.GetCards();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateCardService();

            if (service.CreateCard(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}