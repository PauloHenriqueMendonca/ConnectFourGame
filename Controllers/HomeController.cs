using ConnectFourGame.DB;
using ConnectFourGame.Logic;
using ConnectFourGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectFourGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GameHistory(int userId)
        {
            var games = new GameDB();
            var gameHistory = games.GetMany(userId);
            ViewBag.Message = "Your application description page.";

            return View(gameHistory);
        }

        public ActionResult Game()
        {
            ViewBag.Message = "Your contact page.";

            return View("Game");
        }

        [HttpPost]
        public ActionResult SaveGame(Game model)
        {
            var response = new ResponseModel();

            var game = new GameLogic();
            var newGame = game.Insert(model);

            response.Error = false;

            return Json(response);
        }

        [HttpPost]
        public ActionResult DeleteGame(int gameId)
        {
            var response = new ResponseModel();

            var game = new GameLogic();
            var newGame = game.Delete(gameId);

            return Json(response);
        }
    }
}