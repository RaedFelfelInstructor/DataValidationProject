using DataValidationProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataValidationProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserLogin model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("LoginSuccess");
        }

        // GET: /Account/LoginSuccess
        [HttpGet]
        public IActionResult LoginSuccess()
        {
            return View();
        }

        // Method for remote validation
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckUsername(string username)
        {
            // Simulate checking username against a database
            var takenUsernames = new List<string> { "admin", "root", "system", "moderator", "user"};

            if (takenUsernames.Contains(username.ToLower())) {
                return Json($"The username {username} is already taken.");
            }

            return Json(true);
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserRegistration model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("RegisterationSuccess");
        }

        // GET: /Account/RegisterationSuccess
        [HttpGet]
        public IActionResult RegisterationSuccess() {
            return View();
        }
    }
}
