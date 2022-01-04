using DevBuildDeckOfCardsAPILab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildDeckOfCardsAPILab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DeckDAL DeckDAL = new DeckDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Deck model = new Deck();
            return View(model);
        }

        public IActionResult  NewDeck(Deck model)
        {
            model = DeckDAL.GetDeck();
            //model = DeckDAL.DrawCards(model.deck_id, 5);
            return RedirectToAction("DrawCards", model);
        }

        public IActionResult DrawCards(Deck model)
        {
            model = DeckDAL.DrawCards(model.deck_id, 5);
            return View(model);
        }

        [HttpPost]
        public IActionResult ReshuffleDeck(string deckId)
        {
            Deck model = DeckDAL.Reshuffle(deckId);
            return RedirectToAction("DrawCards", model);
        }

        [HttpPost]
        public IActionResult DrawCards(string deckId)
        {
            Deck model = DeckDAL.DrawCards(deckId, 5);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
