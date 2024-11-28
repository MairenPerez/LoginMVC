using Login.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Validar usuario
                if (model.Username == "admin" && model.Password == "password")
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
            }
            return View(model);
        }
    }
}
