using ConnectFourGame.Logic;
using ConnectFourGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectFourGame.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string user, string password)
        {
            var logic = new UserLogic();
            var usuarioNoBanco = logic.Get(user);

            if (usuarioNoBanco != null)
                if (usuarioNoBanco.Password == password)
                    return RedirectToAction("Index", "Home", new { userId = usuarioNoBanco.UserId, maisUmParametro = "vazio" });

            ViewBag.ErrorMessage = "Login Invalido!";
            return View("Index");
        }

        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(UserVM model)
        {
            try
            {
                // TODO: Add insert logic here
                var logic = new UserLogic();
                var newUser = logic.Insert(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
