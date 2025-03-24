using DataValidationProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataValidationProject.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/Profile
        [HttpGet]
        public IActionResult Profile()
        {
            var model = new UserProfile
            {
                DateOfBirth = DateTime.Today.AddYears(-30),
                PreferredContactMethod = ContactMethod.Email
            };

            return View(model);
        }

        // POST: /User/Profile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(UserProfile model)
        {
            int calculatedAge = DateTime.Today.Year - model.DateOfBirth.Year;
            if (model.DateOfBirth.Date > DateTime.Today.AddYears(-calculatedAge))
            {
                calculatedAge--;
            }

            if (calculatedAge != model.Age)
            {
                ModelState.AddModelError("Age", "Age does not match the provided date of birth");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("ProfileSuccess");
        }

        // Get: /User/ProfileSuccess
        [HttpGet]
        public IActionResult ProfileSuccess()
        {
            return View();
        }

    }
}
